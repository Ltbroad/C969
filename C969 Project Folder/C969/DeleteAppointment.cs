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
    public partial class DeleteAppointment : Form
    {

        public static List<KeyValuePair<string, object>> appointmentList;
        public DeleteAppointment()
        {
            InitializeComponent();
            populateAppointment();
            customerTextBox.Enabled = false;
            titleTextBox.Enabled = false;
            locationTextBox.Enabled = false;
            typeTextBox.Enabled = false;
            startDTP.Enabled = false;
            endDTP.Enabled = false;
            deleteButton.Enabled = false;
        }

        public void setAppointmentList(List<KeyValuePair<string, object>> list)
        {
            appointmentList = list;
        }

        public static List<KeyValuePair<string, object>> getAppointmentList()
        {
            return appointmentList;
        }

        public void populateAppointment()
        {
            MySqlConnection connection = new MySqlConnection(DBHelper.ConnectionString);

            try
            {
                string query = "SELECT appointmentId FROM appointment";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Appoint");
                appComboBox.DisplayMember = "appointmentId";
                appComboBox.ValueMember = "appointmentId";
                appComboBox.DataSource = ds.Tables["Appoint"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred." + ex);
            }
        }

        private void populateFields(List<KeyValuePair<string, object>> appointList)
        {
            //Lambda used to set text values from kvp
            customerTextBox.Text = appointList.First(kvp => kvp.Key == "customerId").Value.ToString();
            titleTextBox.Text = appointList.First(kvp => kvp.Key == "title").Value.ToString();
            locationTextBox.Text = appointList.First(kvp => kvp.Key == "location").Value.ToString();
            typeTextBox.Text = appointList.First(kvp => kvp.Key == "type").Value.ToString();
            string start = appointList.First(kvp => kvp.Key == "start").Value.ToString();
            string end = appointList.First(kvp => kvp.Key == "end").Value.ToString();
            startDTP.Value = Convert.ToDateTime(start).ToLocalTime();
            endDTP.Value = Convert.ToDateTime(end).ToLocalTime();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DataRowView drv = appComboBox.SelectedItem as DataRowView;
            int id = Convert.ToInt32(appComboBox.SelectedValue);
            var appointmentList = DBHelper.appointmentSearch(id);
            setAppointmentList(appointmentList);
            
            if (appointmentList != null)
            {
                deleteButton.Enabled = true;
                populateFields(appointmentList);
                
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Hide();
            Appointments showAppointments = new Appointments();
            showAppointments.Closed += (s, args) => this.Close();
            showAppointments.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm", MessageBoxButtons.YesNo);
            if(confirm == DialogResult.Yes)
            {
                try
                {
                    var list = getAppointmentList();
                    IDictionary<string, object> dictionary = list.ToDictionary(pair => pair.Key, pair => pair.Value);
                    DBHelper.deleteAppointment(dictionary);
                    MessageBox.Show("This appointment has been deleted.");
                    Hide();
                    Appointments showAppointments = new Appointments();
                    showAppointments.Closed += (s, args) => this.Close();
                    showAppointments.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred." + ex);
                }
            }
        }
    }
}
