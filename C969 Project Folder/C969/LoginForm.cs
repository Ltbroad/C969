using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using C968;

namespace C969
{
    public partial class LoginForm : Form
    {
        public string error = Strings.Error;
        public LoginForm()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LanguageTimer_Tick(object sender, EventArgs e) // Use timer tick to load proper language depending on if the culture is EN or DE
        {
            ResourceManager resource = new ResourceManager("rm", typeof(LoginForm).Assembly); // Create resource manager object

            // Load strings from resource files
            this.Text = resource.GetString("LoginForm");
            UserLabel.Text = resource.GetString("UserLabel");
            PassLabel.Text = resource.GetString("PassLabel");
            LoginButton.Text = resource.GetString("LoginButton");
            ExitButton.Text = resource.GetString("ExitButton");
            error = resource.GetString("Error");
        }

        //Method to verify credentials are correct for user login
        static public int FindUser(string userName, string password)
        {
            MySqlConnection connection = new MySqlConnection(DBHelper.ConnectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand($"SELECT userID FROM user WHERE userName = '{userName}' AND password = '{password}'", connection);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                DBHelper.SetUserID(Convert.ToInt32(reader[0]));
                DBHelper.SetUserName(userName);
                reader.Close();
                connection.Close();
                return DBHelper.GetUserID();
            }
            return 0;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (FindUser(usernameTextBox.Text, passwordTextBox.Text) != 0 )
            {
                this.Hide();
                CustomerRecords ShowCustomerRecords = new CustomerRecords();
                TimestampLogging.LogSignIn(DBHelper.GetUserID());
                ShowCustomerRecords.Closed += (s, args) => this.Close();
                ShowCustomerRecords.Show();
            }

            else
            {
                MessageBox.Show(error);
                passwordTextBox.Text = "";
            }
        }
    }
}
