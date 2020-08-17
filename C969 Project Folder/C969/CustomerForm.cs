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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            populateCombo();
        }

        //Populate the city combo box
        public void populateCombo()
        {
            MySqlConnection connection = new MySqlConnection(DBHelper.ConnectionString);

            try
            {
                string query = "SELECT * FROM city";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                comboCityBox.DisplayMember = "city";
                comboCityBox.ValueMember = "cityId";
                comboCityBox.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred." + ex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DataRowView drv = comboCityBox.SelectedItem as DataRowView;
            int cityId = Convert.ToInt32(comboCityBox.SelectedValue);
            string timestamp = DBHelper.createTimestamp();
            string userName = DBHelper.GetUserName();
            if (string.IsNullOrEmpty(nameTextBox.Text) ||
                string.IsNullOrEmpty(streetTextBox.Text) ||
                string.IsNullOrEmpty(comboCityBox.Text) ||
                string.IsNullOrEmpty(zipTextBox.Text) ||
                string.IsNullOrEmpty(phoneNumberTextBox.Text) ||
                (yesRadioButton.Checked == false && noRadioButton.Checked == false))
            {
                MessageBox.Show("Please fill out all of the fields.");
            }
            else
            {
                int addressID = DBHelper.createAddress(streetTextBox.Text, cityId, zipTextBox.Text, phoneNumberTextBox.Text);
                DBHelper.createCustomer(DBHelper.getMaxID("customer", "customerId") + 1, nameTextBox.Text, addressID, yesRadioButton.Checked ? 1 : 0, DBHelper.getDateTime(), DBHelper.GetUserName());
                Hide();
                CustomerRecords showCustRecords = new CustomerRecords();
                showCustRecords.Closed += (s, args) => this.Close();
                showCustRecords.Show();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Hide();
            CustomerRecords showCustRecords = new CustomerRecords();
            showCustRecords.Closed += (s, args) => this.Close();
            showCustRecords.Show();
        }
    }
}
