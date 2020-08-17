using System;
using System.Collections;
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
    public partial class CustomerReport : Form
    {
        //Form to show how many appointments each customer has scheduled

        public struct Customer
        {
            public string customerName;
            public int numberOfApps;
        }

        public CustomerReport()
        {
            InitializeComponent();
            custReportDGV.DataSource = report();
        }

        public static DataTable report()
        {
            // Display each customer's name and how many appointments they have

            Dictionary<int, Hashtable> appointments = DBHelper.getAppointments();
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Customer");
            dt.Columns.Add("Appointments");

            IEnumerable<string> customers = appointments.Select(i => i.Value["customerName"].ToString()).Distinct(); // Lambda used to select each customer distinctly from the appointments collection

            foreach (string customer in customers)
            {
                DataRow row = dt.NewRow();
                row["Customer"] = customer;
                row["Appointments"] = appointments.Where(i => i.Value["customerName"].ToString() == customer.ToString()).Count().ToString(); // Lambda used to count the number of appointments each customer has from appointments collection
                dt.Rows.Add(row);
            }

            return dt;
        }

        private void CustomerReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            Appointments showAppointments = new Appointments();
            showAppointments.Closed += (s, args) => this.Close();
            showAppointments.Show();
        }
    }
}
