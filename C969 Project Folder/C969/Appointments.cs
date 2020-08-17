using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C968
{
    public partial class Appointments : Form
    {
        DataTable dt = new DataTable();
        DateTime currentDate;
        public int customerIDNumber;

        public Appointments()
        {
            InitializeComponent();
            currentDate = DateTime.Now;
            monthlyCalendar.AddBoldedDate(currentDate);
            monthlyWeeklyApptDataGrid.DataSource = getCalendar(rbWeek.Checked);
            reminder(monthlyWeeklyApptDataGrid); //Reminder message for appointments scheduled in the next 15 minutes
        }

        public static void reminder(DataGridView calendar)
        {
            foreach (DataGridViewRow row in calendar.Rows)
            {
                DateTime now = DateTime.UtcNow;
                DateTime start = DateTime.Parse(row.Cells[2].Value.ToString()).ToUniversalTime();
                TimeSpan timeSpan = now - start;
                if (timeSpan.TotalMinutes >= -15 && timeSpan.TotalMinutes < 1)
                {
                    MessageBox.Show($"You have a meeting with {row.Cells[4].Value} at {row.Cells[2].Value}");
                }
            }
        }

        private void getData(string s)
        {
            using (MySqlConnection connection = new MySqlConnection(DBHelper.ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(s, connection);
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dt);
                connection.Close();
            }
        }

        //View for appointments scheduled on the week selected in the calendar
        private void showWeek()
        {
            monthlyCalendar.RemoveAllBoldedDates();
            dt.Clear();
            int dow = (int)currentDate.DayOfWeek;
            string startDate = currentDate.AddDays(-dow).ToString("yyyy-MM-dd HH:mm:ss");
            DateTime tempDate = Convert.ToDateTime(startDate);
            for (int i = 0; i < 7; i++)
            {
                monthlyCalendar.AddBoldedDate(tempDate.AddDays(i));
            }
            monthlyCalendar.UpdateBoldedDates();
            string endDate = currentDate.AddDays(7 - dow).ToString("yyyy-MM-dd HH:mm:ss");
            getData($"SELECT * FROM appointment WHERE (start BETWEEN ' " + startDate + " ' AND ' " + endDate + " ')");

            monthlyWeeklyApptDataGrid.DataSource = dt;
        }

        //View for appointments scheduled for the month selected on the calendar
        private void showMonth()
        {
            monthlyCalendar.RemoveAllBoldedDates();
            dt.Clear();
            int month = currentDate.Month;
            int year = currentDate.Year;
            int day = 1;
            int date = 0;
            string startDate = year.ToString() + "-" + month.ToString() + "-" + day.ToString();
            DateTime tempDate = Convert.ToDateTime(startDate);
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                    date = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    date = 30;
                    break;
                default:
                    date = 29;
                    break;
            }
            for (int i = 0; i < date; i++)
            {
                monthlyCalendar.AddBoldedDate(tempDate.AddDays(i));
            }
            monthlyCalendar.UpdateBoldedDates();
            string endDate = year.ToString() + "-" + month.ToString() + "-" + date.ToString();
            getData("SELECT * FROM appointment WHERE (start BETWEEN ' " + startDate + " ' AND ' " + endDate + " ')");
            monthlyWeeklyApptDataGrid.DataSource = dt;
        }

        static public Array getCalendar(bool viewWeek)
        {
            MySqlConnection connection = new MySqlConnection(DBHelper.ConnectionString);
            connection.Open();
            string query = $"SELECT customerId, type, start, end, appointmentId, userId FROM appointment WHERE userId = '{DBHelper.GetUserID()}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            Dictionary<int, Hashtable> _appointments = new Dictionary<int, Hashtable>();

            while (reader.Read())
            {
                Hashtable appointment = new Hashtable();
                appointment.Add("customerId", reader[0]);
                appointment.Add("type", reader[1]);
                appointment.Add("start", reader[2]);
                appointment.Add("end", reader[3]);
                appointment.Add("userId", reader[5]);

                _appointments.Add(Convert.ToInt32(reader[4]), appointment);
            }
            reader.Close();

            foreach (var app in _appointments.Values)
            {
                query = $"SELECT userName FROM user WHERE userId = '{app["userId"]}'";
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();
                reader.Read();
                app.Add("userName", reader[0]);
                reader.Close();
            }

            foreach (var app in _appointments.Values)
            {
                query = $"SELECT customerName FROM customer WHERE customerId = '{app["customerId"]}'";
                command = new MySqlCommand(query, connection);
                reader = command.ExecuteReader();
                reader.Read();
                app.Add("customerName", reader[0]);
                reader.Close();
            }

            Dictionary<int, Hashtable> weekMonthAppointments = new Dictionary<int, Hashtable>();

            foreach (var app in _appointments)
            {
                DateTime startTime = DateTime.Parse(app.Value["start"].ToString());
                DateTime endTime = DateTime.Parse(app.Value["end"].ToString());
                DateTime today = DateTime.UtcNow;

                if (viewWeek)
                {
                    DateTime sunday = today.AddDays(-(int)today.DayOfWeek);
                    DateTime saturday = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Saturday);

                    if (startTime >= sunday && endTime < saturday)
                    {
                        weekMonthAppointments.Add(app.Key, app.Value);
                    }
                }
                else
                {
                    DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
                    DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                    if (startTime >= firstDayOfMonth && endTime < lastDayOfMonth)
                    {
                        weekMonthAppointments.Add(app.Key, app.Value);
                    }
                }
            }

            DBHelper.setAppointments(_appointments);
            var appointmentArray = from row in weekMonthAppointments
                                   select new
                                   {
                                       ID = row.Key,
                                       Type = row.Value,
                                       StartTime = DBHelper.timezoneConvert(row.Value["start"].ToString()),
                                       EndTime = DBHelper.timezoneConvert(row.Value["end"].ToString()),
                                       Customer = row.Value["customerName"]
                                   };
            connection.Close();
            return appointmentArray.ToArray();
        }

        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            Hide();
            AddAppointment showAddAppointment = new AddAppointment();
            showAddAppointment.Closed += (s, args) => this.Close();
            showAddAppointment.Show();
        }

        private void updateAppointmentButton_Click(object sender, EventArgs e)
        {
            Hide();
            UpdateAppointment showUpdateAppointment = new UpdateAppointment();
            showUpdateAppointment.Closed += (s, args) => this.Close();
            showUpdateAppointment.Show();
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            Hide();
            DeleteAppointment showDeleteAppointment = new DeleteAppointment();
            showDeleteAppointment.Closed += (s, args) => this.Close();
            showDeleteAppointment.Show();
        }

        private void monthlyCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Hide();
            CustomerRecords showCustRecords = new CustomerRecords();
            showCustRecords.Closed += (s, args) => this.Close();
            showCustRecords.Show();
        }

        private void appointmentsReport_Click(object sender, EventArgs e)
        {
            Hide();
            MonthlyAppointments showMonthlyAppointment = new MonthlyAppointments();
            showMonthlyAppointment.Closed += (s, args) => this.Close();
            showMonthlyAppointment.Show();
        }

        private void schedulesReport_Click(object sender, EventArgs e)
        {
            Hide();
            UserSchedules showUserSchedules = new UserSchedules();
            showUserSchedules.Closed += (s, args) => this.Close();
            showUserSchedules.Show();
        }

        private void customersAndAppointmentsReport_Click(object sender, EventArgs e)
        {
            Hide();
            CustomerReport showCustomerReport = new CustomerReport();
            showCustomerReport.Closed += (s, args) => this.Close();
            showCustomerReport.Show();
        }

        private void rbWeek_CheckedChanged(object sender, EventArgs e)
        {
            showWeek();
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            showMonth();
        }

        private void monthlyCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            currentDate = e.Start;
            if (rbMonth.Checked)
            {
                showMonth();
            }
            else
            {
                if (rbWeek.Checked)
                {
                    showWeek();
                }
            }
        }

        private void Appointments_Load(object sender, EventArgs e)
        {

        }
    }
}
