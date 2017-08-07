using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Salon
{   
    abstract class dbConnect : MainWindow   //klasa sluzaca do ustanawiania polaczenia z baza danych
    {
        public static bool ifConnected = false;
        public static string user;
        public static string passwd;
        //funkcja przyjmujaca jako argumenty nazwe uzytkownika i haslo, nastepnie sprawdza czy jest polaczenie z baza danych
        public static void connect(string user, string passwd)
        {
            dbConnect.user = user;
            dbConnect.passwd = passwd;
            //connection check
            if (checkDB_conn())
                ifConnected = true;
            else if (!checkDB_conn())
                ifConnected = false;
        }

        public static string database_conn()
        {
            string mysqldata = "Database=akademia;Data Source=mysql5.gear.host;User Id=" + user + ";Password=" + passwd;
            return mysqldata;
        }
        //funkcja sprawdzajaca polaczenie z baza danych - sprawdza poprawnosc nazwy uzytkownika i hasla.
        //jesli user i password sa poprawne funkcja zwraca true, a jesli nie - false
        public static bool checkDB_conn()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(database_conn());
                conn.Open();
                if (conn.State == ConnectionState.Open)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
