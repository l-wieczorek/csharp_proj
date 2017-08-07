using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Salon
{
    class Workers : dbConnect
    {
        public static bool ifCorrect;

        public static string f_name;
        public static string l_name;
        public static DateTime dateofbirthTemp;
        public static string dateofbirth;
        public static string address;
        public static int salary;
        public static DateTime dateofengagementTemp;
        public static string dateofengagement;
        public static int phonenumber;
        public static string email;

        public static void AddWorker(string FirstName, string LastName, string DateOfBirth, string Address, int Salary, string DateOfEngagement, int PhoneNumber, string email)
        {
            MySqlConnection conn = new MySqlConnection(database_conn());

            string insertQuery = "INSERT INTO workers(FirstName, LastName, DateOfBirth, Address, Salary, DateOfEngagement, PhoneNumber, email) VALUES('" + FirstName + "','" + LastName + "',DATE '" + DateOfBirth + "','" + Address + "'," + Salary + ",DATE '" + DateOfEngagement + "'," + PhoneNumber + ",'"+ email + "')";
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            try
            {
                conn.Open();
                if (command.ExecuteNonQuery() == 1)
                    ifCorrect = true;
                else
                {
                    ifCorrect = false;
                    Console.WriteLine("false");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        }

        public static void RemoveWorker(int ID)
        {
            MySqlConnection conn = new MySqlConnection(database_conn());

            string insertQuery = "DELETE FROM workers WHERE ID="+ID;
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

        public static void EditWorker(int ID, string FirstName, string LastName, string DateOfBirth, string Address, int Salary, string DateOfEngagement, int PhoneNumber, string email)
        {
            MySqlConnection conn = new MySqlConnection(database_conn());
            string insertQuery = "UPDATE workers SET FirstName='"+FirstName+"',LastName='"+LastName+"',DateOfBirth=DATE '" + DateOfBirth +"', Address='" + Address + "', Salary=" + Salary +", DateOfEngagement=DATE '"+ DateOfEngagement +"', PhoneNumber=" + PhoneNumber +", email='" + email +"' WHERE ID="+ID;
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

                string sql = "SELECT * FROM workers WHERE ID="+ID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    f_name = (string)reader[1];
                    l_name = (string)reader[2];
                    dateofbirthTemp = (DateTime)reader[3];
                    dateofbirth = dateofbirthTemp.ToString("yyyy-MM-dd");
                    address = (string)reader[4];
                    salary = (int)reader[5];
                    dateofengagementTemp = (DateTime)reader[6];
                    dateofengagement = dateofengagementTemp.ToString("yyyy-MM-dd");
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

        public static DataTable ShowWorkers()
        {
            DataTable myTable = new DataTable("workers");
            MySqlConnection conn = new MySqlConnection(database_conn());
            try
            {
                conn.Open();

                string sql = "SELECT * FROM workers";
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

        public static DataTable FilterWorkers(string LastName)
        {
            DataTable myTable = new DataTable("workers");
            MySqlConnection conn = new MySqlConnection(database_conn());
            try
            {
                conn.Open();

                string sql = "SELECT * FROM workers WHERE LastName='" + LastName + "'";
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
