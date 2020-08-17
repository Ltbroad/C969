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
    public partial class DeleteCustomerForm : Form
    {
        public DeleteCustomerForm()
        {
            InitializeComponent();
            populateCombo();
            nameTextBox.Enabled = false;
            streetTextBox.Enabled = false;
            cityTextBox.Enabled = false;
            zipTextBox.Enabled = false;
            countryTextBox.Enabled = false;
            phoneNumberTextBox.Enabled = false;
            yesRadioButton.Enabled = false;
            noRadioButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        public static Dictionary<string, string> customerRec = new Dictionary<string, string>();

        public static Dictionary<string, string> getCustomerRec()
        {
            return customerRec;
        }

        public static void setCustomerRec(Dictionary<string, string> dictionary)
        {
            customerRec = dictionary;
        }

        public void populateCombo()
        {
            MySqlConnection connection = new MySqlConnection(DBHelper.ConnectionString);
            try
            {
                string query = "SELECT customerId, CONCAT(customerName, '-- ID: ', customerId) as Display FROM customer;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                connection.Open();
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Cust");
                custSelectComboBox.DisplayMember = "Display";
                custSelectComboBox.ValueMember = "customerId";
                custSelectComboBox.DataSource = dataSet.Tables["Cust"];
            }
            catch
            {
                MessageBox.Show("An error occurred.");
            }
        }

        public void deleteCustomer()
        {
            MySqlConnection connection = new MySqlConnection(DBHelper.ConnectionString);
            connection.Open();

            //Delete customer and update table
            var deleteRecord = "DELETE FROM customer" +
                $" WHERE customerId = '{customerRec["customerId"]}'";
            MySqlCommand command = new MySqlCommand(deleteRecord, connection);
            MySqlTransaction transaction = connection.BeginTransaction();

            command.CommandText = deleteRecord;
            command.Connection = connection;
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            transaction.Commit();

            //Delete address and update table
            transaction = connection.BeginTransaction();
            var deleteRecord2 = "DELETE FROM address" +
                $" WHERE addressId = '{customerRec["addressId"]}'";
            command = new MySqlCommand(deleteRecord, connection);
            int updateAdd = command.ExecuteNonQuery();

            command.CommandText = deleteRecord2;
            command.Connection = connection;
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            transaction.Commit();

            connection.Close();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Hide();
            CustomerRecords showCustRecords = new CustomerRecords();
            showCustRecords.Closed += (s, args) => this.Close();
            showCustRecords.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?",
            "Confirm delete.", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var dictionary = getCustomerRec();
                    bool appointment = DBHelper.checkAppointment(dictionary["customerId"].ToString());
                    if (appointment == false)
                    {
                        deleteCustomer();
                        MessageBox.Show("Customer has been deleted.");
                        Hide();
                        CustomerRecords showCustRecords = new CustomerRecords();
                        showCustRecords.Closed += (s, args) => this.Close();
                        showCustRecords.Show();
                    }
                    else
                    {
                        DialogResult confirm = MessageBox.Show("Delete this customer will also remove all associated appointments. Would you like to continue?", "",
                            MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            DBHelper.deleteCustAppointments(dictionary["customerId"].ToString());
                            deleteCustomer();
                            Hide();
                            CustomerRecords showCustRecords = new CustomerRecords();
                            showCustRecords.Closed += (s, args) => this.Close();
                            showCustRecords.Show();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred." + ex);
                }
            }
            else
            {
                return;
            }
        }

        private void yesRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void noRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void populateFields(Dictionary<string, string> customerRec)
        {
            nameTextBox.Text = customerRec["customerName"];
            streetTextBox.Text = customerRec["address"];
            cityTextBox.Text = customerRec["city"];
            zipTextBox.Text = customerRec["postalCode"];
            countryTextBox.Text = customerRec["country"];
            phoneNumberTextBox.Text = customerRec["phone"];
            if (customerRec["active"] == "True")
            {
                yesRadioButton.Checked = true;
            }
            else
            {
                noRadioButton.Checked = true;
            }
        }

        private void selectCustButton_Click(object sender, EventArgs e)
        {
            DataRowView dataRowView = custSelectComboBox.SelectedItem as DataRowView;
            int custId = Convert.ToInt32(custSelectComboBox.SelectedValue);
            var customerList = DBHelper.CustomerInfo(custId);
            setCustomerRec(customerList);
            if (customerRec != null)
            {
                deleteButton.Enabled = true;
                populateFields(customerList);
            }

        }
    }
}
