using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Salon
{
    class Cars : dbConnect
    {
        public static bool ifCorrect = false;

        public static string model;
        public static int yearofprod;
        public static string eq;
        public static string vin;
        public static int mileage;
        public static string engine;
        public static int horsepow;
        public static string color;

        public static void AddCar(string Model, int YearOfProduction, string Equipment, string VIN, int Mileage, string EngineType, int Horsepower, string Color)
        {
            MySqlConnection conn = new MySqlConnection(database_conn());
            //querka odpowiadajaca za dodanie do tabeli informacji nt. samochodu
            string insertQuery = "INSERT INTO cars(Model, YearOfProduction, Equipment, VIN, Mileage, EngineType, Horsepower, Color) VALUES('" + Model + "'," + YearOfProduction + ",'" + Equipment + "','" + VIN + "'," + Mileage + ",'" + EngineType + "'," + Horsepower + ",'" + Color + "')";
            MySqlCommand command = new MySqlCommand(insertQuery, conn);
            try
            {
                //otwieramy polaczenie i sprawdzamy czy querka sie wykonala czy nie 
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
        //analogicznie
        public static void RemoveCar(int ID)
        {
            MySqlConnection conn = new MySqlConnection(database_conn());

            string insertQuery = "DELETE FROM cars WHERE ID=" + ID;
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
        //analogicznie
        public static void EditCar(int ID, string Model, int YearOfProduction, string Equipment, string VIN, int Mileage, string EngineType, int Horsepower, string Color)
        {
            MySqlConnection conn = new MySqlConnection(database_conn());
            string insertQuery = "UPDATE cars SET Model='" + Model + "',YearOfProduction=" + YearOfProduction + ",Equipment='" + Equipment + "',VIN='" + VIN + "', Mileage=" + Mileage + ", EngineType='" + EngineType + "', Horsepower=" + Horsepower + ", Color='" + Color + "' WHERE ID=" + ID;
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
        //pobranie danych z db w celu edycji
        public static void loadData(int ID)
        {
            MySqlConnection conn = new MySqlConnection(database_conn());
            try
            {
                conn.Open();

                string sql = "SELECT * FROM cars WHERE ID=" + ID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    model = (string)reader[1];
                    yearofprod = (int)reader[2];
                    eq = (string)reader[3];
                    vin = (string)reader[4];
                    mileage = (int)reader[5];
                    engine = (string)reader[6];
                    horsepow = (int)reader[7];
                    color = (string)reader[8];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        //funkcja zwrajaca cala tabele
        public static DataTable ShowCars()
        {
            DataTable myTable = new DataTable("cars");
            MySqlConnection conn = new MySqlConnection(database_conn());
            try
            {
                //otwieramy polaczenie i wypelniamy tabele zwracanymi rekordami
                conn.Open();
                string sql = "SELECT * FROM cars";
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
        //analogicznie jednak querka posiada warunek.
        public static DataTable FilterCars(string VIN)
        {
            DataTable myTable = new DataTable("cars");
            MySqlConnection conn = new MySqlConnection(database_conn());
            try
            {
                conn.Open();
                string sql = "SELECT * FROM cars WHERE VIN='" + VIN + "'";
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
