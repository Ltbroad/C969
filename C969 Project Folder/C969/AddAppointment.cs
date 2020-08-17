using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C968
{
    public partial class AddAppointment : Form
    {
        public AddAppointment()
        {
            InitializeComponent();
            fillCustCombo();
            endDTP.Value = endDTP.Value.AddMinutes(30);
        }

        public void fillCustCombo()
        {
            MySqlConnection connection = new MySqlConnection(DBHelper.ConnectionString);
            try
            {
                string query = "SELECT customerId, CONCAT(customerName, ' -- ID: ', customerId) as Display FROM customer;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Cust");
                custComboBox.DisplayMember = "Display";
                custComboBox.ValueMember = "customerId";
                custComboBox.DataSource = ds.Tables["Cust"];
            }
            catch
            {
                MessageBox.Show("An error occurred.");
            }
        }

        public int appointmentValidator(DateTime startTime, DateTime endTime)
        {
            DateTime localStart = startTime.ToLocalTime();
            DateTime localEnd = endTime.ToLocalTime();
            DateTime businessStart = DateTime.Today.AddHours(8); //8AM
            DateTime businessEnd = DateTime.Today.AddHours(17); //5PM

            //1 for outside business hours
            if (localStart.TimeOfDay < businessStart.TimeOfDay || localEnd.TimeOfDay > businessEnd.TimeOfDay)
            {
                return 1;
            }
            // 2 for overlapping appointments
            if (DBHelper.overlapAppointment(startTime, endTime) !=0)
            {
                return 2;
            }
            //3 for ending time before starting time
            if (localStart.TimeOfDay > localEnd.TimeOfDay)
            {
                return 3;
            }
            //4 for appointment times not on the same day
            if (localStart.ToShortDateString() != localEnd.ToShortDateString())
            {
                return 4;
            }
            //0 for pass
            return 0;
        }

        private bool emptyCheck()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        return false;
                    }
                }
                if (c is ComboBox)
                {
                    ComboBox combo = c as ComboBox;
                    if (combo.SelectedIndex == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void showError(string item)
        {
            MessageBox.Show("Please enter a valid information for " + item);

        }

        //Method to validate all fields are filled out
        private bool validate()
        {
            if (emptyCheck() == false)
            {
                MessageBox.Show("Please fill out all fields.");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(titleTextBox.Text, "[^a-zA-Z]+$"))
            {
                showError(label2.Text);
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(typeTextBox.Text, "[^a-zA-Z]+$"))
            {
                showError(label3.Text);
                return false;
            }

            return true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            bool pass = validate();
            if (pass)
            {
                if (custComboBox.SelectedItem != null)
                {
                    DataRowView dataRowView = custComboBox.SelectedItem as DataRowView;
                    int custID = Convert.ToInt32(custComboBox.SelectedValue);

                    DateTime startTime = startDTP.Value.ToUniversalTime();
                    DateTime endTime = endDTP.Value.ToUniversalTime();

                    int validate = appointmentValidator(startTime, endTime);

                    switch (validate)
                    {
                        case 1:
                            MessageBox.Show("This appointment isn't within business hours.");
                                break;
                        case 2:
                            MessageBox.Show("This appointment conflict with another appointment.");
                                break;
                        case 3:
                            MessageBox.Show("The appointments start time is after the end time.");
                                break;
                        case 4:
                            MessageBox.Show("The start and end date are not on the same date.");
                                break;
                        default:
                            DBHelper.createAppointment(custID, titleTextBox.Text, typeTextBox.Text, startTime, endTime);
                            MessageBox.Show("Appointment has been added.");
                            Hide();
                            Appointments showAppointments = new Appointments();
                            showAppointments.Closed += (s, args) => this.Close();
                            showAppointments.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer.");
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Hide();
            Appointments showAppointments = new Appointments();
            showAppointments.Closed += (s, args) => this.Close();
            showAppointments.Show();
        }
    }
}
