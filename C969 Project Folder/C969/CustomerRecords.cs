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
    public partial class CustomerRecords : Form
    {
        public CustomerRecords()
        {
            InitializeComponent();
            MySqlConnection sqlConnection = new MySqlConnection(DBHelper.ConnectionString);
            sqlConnection.Open();
            string s = "SELECT * FROM customer";
            MySqlCommand sqlCommand = new MySqlCommand(s, sqlConnection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable customerTable = new DataTable();
            dataAdapter.Fill(customerTable);
            customerDataGrid.DataSource = customerTable;
            
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerForm showCustomerForm = new CustomerForm();
            showCustomerForm.Closed += (s, args) => this.Close();
            showCustomerForm.Show();
            
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateCustomer showUpdateCustomerForm = new UpdateCustomer();
            showUpdateCustomerForm.Closed += (s, args) => this.Close();
            showUpdateCustomerForm.Show();
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteCustomerForm showDeleteCustomerForm = new DeleteCustomerForm();
            showDeleteCustomerForm.Closed += (s, args) => this.Close();
            showDeleteCustomerForm.Show();
        }

        private void appointmentsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appointments showAppointments = new Appointments();
            showAppointments.Closed += (s, args) => this.Close();
            showAppointments.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customerDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
