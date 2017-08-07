using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Salon
{
    class Clients : dbConnect
    {
        public static bool ifCorrect = false;

        public static string f_name;
        public static string l_name;
        public static DateTime dateofbirthTemp;
        public static string dateofbirth;
        public static string address;
        public static string productbought;
        public static DateTime dateofpurchaseTemp;
        public static string dateofpurchase;
        public static int phonenumber;
        public static string email;

        public static void AddClient(string FirstName, string LastName, string DateOfBirth, string Address, string ProductBought, string DateOfPurchase, int PhoneNumber, string email)
        {
            MySqlConnection conn = new MySqlConnection(database_conn());

            string insertQuery = "INSERT INTO clients(FirstName, LastName, DateOfBirth, Address, ProductBought, DateOfPurchase, PhoneNumber, email) VALUES('" + FirstName + "','" + LastName + "',DATE '" + DateOfBirth + "','" + Address + "','" + ProductBought + "',DATE '" + DateOfPurchase + "'," + PhoneNumber + ",'" + email + "')";
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() == 1)
                    ifCorrect = true;
                else
                    ifCorrect = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        }

        public static void RemoveClient(int ID)
        {
            MySqlConnection conn = new MySqlConnection(database_conn());

            string insertQuery = "DELETE FROM clients WHERE ID=" + ID;
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() == 1)
                    ifCorrect = true;
                else
                    ifCorrect = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        }

        public static void EditClient(int ID, string FirstName, string LastName, string DateOfBirth, string Address, string ProductBought, string DateOfPurchase, int PhoneNumber, string email)
        {
            MySqlConnection conn = new MySqlConnection(database_conn());
            string insertQuery = "UPDATE clients SET FirstName='" + FirstName + "',LastName='" + LastName + "',DateOfBirth=DATE '" + DateOfBirth + "', Address='" + Address + "', ProductBought='" + ProductBought + "', DateOfPurchase=DATE '" + DateOfPurchase + "', PhoneNumber=" + PhoneNumber + ", email='" + email + "' WHERE ID=" + ID;
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() == 1)
                    ifCorrect = true;
                else
                    ifCorrect = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        }

        public static void loadData(int ID)
        {
            MySqlConnection conn = new MySqlConnection(database_conn());
            try
            {
                conn.Open();

                string sql = "SELECT * FROM clients WHERE ID=" + ID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    f_name = (string)reader[1];
                    l_name = (string)reader[2];
                    dateofbirthTemp = (DateTime)reader[3];
                    dateofbirth = dateofbirthTemp.ToString("yyyy-MM-dd");
                    address = (string)reader[4];
                    productbought = (string)reader[5];
                    dateofpurchaseTemp = (DateTime)reader[6];
                    dateofpurchase = dateofpurchaseTemp.ToString("yyyy-MM-dd");
                    phonenumber = (int)reader[7];
                    email = (string)reader[8];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        public static DataTable ShowClients()
        {
            DataTable myTable = new DataTable("clients");
            MySqlConnection conn = new MySqlConnection(database_conn());
            try
            {
                conn.Open();

                string sql = "SELECT * FROM clients";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.Fill(myTable);
                adapter.Update(myTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            return myTable;
        }

        public static DataTable FilterClients(string LastName)
        {
            DataTable myTable = new DataTable("clients");
            MySqlConnection conn = new MySqlConnection(database_conn());
            try
            {
                conn.Open();

                string sql = "SELECT * FROM clients WHERE LastName='" + LastName + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.Fill(myTable);
                adapter.Update(myTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            return myTable;
        }
    }
}
