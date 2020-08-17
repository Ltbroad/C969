using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C968
{
    class DBHelper
    {
        public static string ConnectionString = "server=3.227.166.251 ; database=U05KOe ; uid=U05KOe ; pwd =  53688527251; convert zero datetime=True;";
        private static Dictionary<int, Hashtable> _appointments = new Dictionary<int, Hashtable>();
        public static Dictionary<string, string> Update = new Dictionary<string, string>();

        private static string userName;
        private static int userID;


        public static int GetUserID()
        {
            return userID;
        }

        public static void SetUserID(int currentUserID)
        {
            userID = currentUserID;
        }

        public static string GetUserName()
        {
            return userName;
        }

        public static void SetUserName(string currentUserName)
        {
            userName = currentUserName;
        }

        public static string createTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static void setAppointments(Dictionary<int, Hashtable> appointments)
        {
            _appointments = appointments;
        }

        public static Dictionary<int, Hashtable> getAppointments()
        {
            return _appointments;
        }

        public static DateTime getDateTime()
        {
            return DateTime.Now.ToUniversalTime();
        }

        public static string timezoneConvert(string dateTime)
        {
            DateTime utcDateTime = DateTime.Parse(dateTime.ToString());
            DateTime localDateTime = utcDateTime.ToLocalTime();

            return localDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string SQLTimeFormat(DateTime dateTime)
        {
            string format = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return format;
        }

        public static void createCustomer(int customerId, string name, int addressId, int active, DateTime dateTime, string userName)
        {
            string sqlDate = SQLTimeFormat(dateTime);
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            MySqlTransaction transaction = connection.BeginTransaction();
            var query = "INSERT into customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdateBy)" +
                $"VALUES ('{customerId}', '{name}', '{addressId}', '{active}', '{SQLTimeFormat(dateTime)}', '{userName}', '{userName}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
        }

        public static int newID(List<int> IDList)
        {
            int highestID = 0;
            foreach (int id in IDList)
            {
                if (id > highestID)
                    highestID = id;
            }
            return highestID + 1;
        }

        public static int getMaxID(string table, string customerID)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var query = $"SELECT MAX({customerID}) FROM ({table})";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                if(reader[0] == DBNull.Value)
                {
                    return 0;
                }
                return Convert.ToInt32(reader[0]);
            }
            return 0;
        }

        public static Dictionary<string, string> CustomerInfo(int customerId)
        {
            string query = $"SELECT * FROM customer WHERE customerId = '{customerId}'";
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();

            Dictionary<string, string> CustomerLookup = new Dictionary<string, string>();
            CustomerLookup.Add("customerId", reader[0].ToString());
            CustomerLookup.Add("customerName", reader[1].ToString());
            CustomerLookup.Add("addressId", reader[2].ToString());
            CustomerLookup.Add("active", reader[3].ToString());
            reader.Close();

            query = $"SELECT * FROM address WHERE addressId = '{CustomerLookup["addressId"]}'";
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            reader.Read();

            CustomerLookup.Add("address", reader[1].ToString());
            CustomerLookup.Add("cityId", reader[3].ToString());
            CustomerLookup.Add("postalCode", reader[4].ToString());
            CustomerLookup.Add("phone", reader[5].ToString());
            reader.Close();

            query = $"SELECT * FROM city WHERE cityId = '{CustomerLookup["cityId"]}'";
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            reader.Read();

            CustomerLookup.Add("city", reader[1].ToString());
            CustomerLookup.Add("countryId", reader[2].ToString());
            reader.Close();

            query = $"SELECT * FROM country WHERE countryId = '{CustomerLookup["countryId"]}'";
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            reader.Read();

            CustomerLookup.Add("country", reader[1].ToString());
            reader.Close();
            connection.Close();

            return CustomerLookup;
        }

        public static bool checkAppointment(string customerID)
        {
            Console.WriteLine(customerID);
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var query = $"SELECT * FROM appointment WHERE customerId = '{customerID}'";

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public static void deleteCustAppointments(string customerID)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var query = $"DELETE FROM appointment" +
                $" WHERE customerId = '{customerID}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlTransaction transaction = connection.BeginTransaction();
            command.CommandText = query;
            command.Connection = connection;
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
        }

        public static int overlapAppointment(DateTime start, DateTime end)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var query = $"SELECT count(*) FROM appointment WHERE (('{SQLTimeFormat(start.ToUniversalTime())}' > start and '{SQLTimeFormat(start.ToUniversalTime())}' < end) or ('{SQLTimeFormat(end.ToUniversalTime())}'> start and '{SQLTimeFormat(end.ToUniversalTime())}' < end)) and end > now() order by start limit 1;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                reader.Read();
                string count = reader[0].ToString();
                int result = count == "0" ? 0 : 1;
                return result;
            }
            return 0;
        }

        public static List<KeyValuePair<string, object>> appointmentSearch(int appID)
        {
            var list = new List<KeyValuePair<string, object>>();
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var query = $"SELECT * FROM appointment WHERE appointmentId = {appID}";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    list.Add(new KeyValuePair<string, object>("appointmentId", reader[0]));
                    list.Add(new KeyValuePair<string, object>("customerId", reader[1]));
                    list.Add(new KeyValuePair<string, object>("title", reader[3]));
                    list.Add(new KeyValuePair<string, object>("location", reader[5]));
                    list.Add(new KeyValuePair<string, object>("type", reader[7]));
                    list.Add(new KeyValuePair<string, object>("start", reader[9]));
                    list.Add(new KeyValuePair<string, object>("end", reader[10]));
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("No appointment found with ID: " + appID, "Please try again.");
                    return null;
                }
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured." + ex);
                return null;
            }
        }

        public static void createAppointment(int customerID, string title, string type, DateTime start, DateTime end)
        {
            int appointmentID = getMaxID("appointment", "appointmentId") + 1;
            int userID = GetUserID();
            string url = "not needed";
            string description = "not needed";
            string contact = "not needed";
            string location = "not needed";
            DateTime utc = getDateTime();
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            MySqlTransaction transaction = connection.BeginTransaction();
            var query = "INSERT INTO appointment (appointmentId, customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) " +
                $" VALUES ('{appointmentID}', '{customerID}', '{userID}', '{title}', '{description}', '{location}', '{contact}', '{type}', '{url}', '{SQLTimeFormat(start)}', '{SQLTimeFormat(end)}', '{SQLTimeFormat(utc)}', '{userID}', '{userID}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
        }

        public static void updateAppointment(IDictionary<string, object> dictionary)
        {
            string user = GetUserName();
            DateTime utc = getDateTime();
            DateTime startTime = Convert.ToDateTime(dictionary["start"]);
            DateTime endTime = Convert.ToDateTime(dictionary["end"]);
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            MySqlTransaction transaction = connection.BeginTransaction();
            var query = $"UPDATE appointment" +
                $" SET customerId = '{dictionary["customerId"]}', title = '{dictionary["title"]}', " +
                $" type = '{dictionary["type"]}', start = '{SQLTimeFormat(startTime.ToUniversalTime())}', end = '{SQLTimeFormat(endTime.ToUniversalTime())}', lastUpdate = '{SQLTimeFormat(utc)}', lastUpdateBy = '{user}' " +
                $" WHERE appointmentId = '{dictionary["appointmentId"]}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
        }

        public static void deleteAppointment(IDictionary<string, object> dictionary)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            var query = $"DELETE FROM appointment" +
                $" WHERE appointmentId = '{dictionary["appointmentId"]}'";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlTransaction transaction = connection.BeginTransaction();
            command.CommandText = query;
            command.Connection = connection;
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
        }

        public static int createAddress(string address, int cityID, string postalCode, string phone)
        {
            int addressID = getMaxID("address", "addressId") + 1;
            string address2 = null;
            

            string user = GetUserName();
            DateTime utc = getDateTime();
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            MySqlTransaction transaction = connection.BeginTransaction();
            var query = "INSERT INTO address (addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy)" +
                $" VALUES ('{addressID}', '{address}', '{address2}', '{cityID}', '{postalCode}', '{phone}', '{SQLTimeFormat(utc)}', '{user}', '{user}')";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();

            return addressID;
        }
    }
}
