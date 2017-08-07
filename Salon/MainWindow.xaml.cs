using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Salon
{
    // klasa z głównym oknem aplikacji
    public partial class MainWindow : Window
    {
        // zmienne boolowskie niezbędne do prawidłowej nawigacji pomiędzy oknami
        bool ifWorkersClicked;
        bool ifCarsClicked;
        bool ifClientsClicked;
        bool ifActionClicked;
        bool ifAddClicked = false;
        bool ifRemoveClicked = false;
        bool ifEditClicked = false;

        public MainWindow()
        {
            // Visibility elementów (collapsed - niewidoczny, visible - widoczny) użyto dlatego, że kolejn okna nie różnią się znacząco od siebie
            InitializeComponent();
            ifWorkersClicked = false;
            ifCarsClicked = false;
            ifClientsClicked = false;
            ifActionClicked = false;
            category.Visibility = Visibility.Collapsed;
            button_back.Visibility = Visibility.Collapsed;
            button_add.Visibility = Visibility.Collapsed;
            button_edit.Visibility = Visibility.Collapsed;
            button_remove.Visibility = Visibility.Collapsed;
            button_show.Visibility = Visibility.Collapsed;
            button_load.Visibility = Visibility.Collapsed;
            textBox1.Visibility = Visibility.Collapsed;
            textBox2.Visibility = Visibility.Collapsed;
            textBox3.Visibility = Visibility.Collapsed;
            textBox4.Visibility = Visibility.Collapsed;
            textBox5.Visibility = Visibility.Collapsed;
            textBox6.Visibility = Visibility.Collapsed;
            textBox7.Visibility = Visibility.Collapsed;
            textBox8.Visibility = Visibility.Collapsed;
            textBox9.Visibility = Visibility.Collapsed;
            textBox10.Visibility = Visibility.Collapsed;
            button_confirm.Visibility = Visibility.Collapsed;
            View_workers_database.Visibility = Visibility.Collapsed;
            View_cars_database.Visibility = Visibility.Collapsed;
            View_clients_database.Visibility = Visibility.Collapsed;

        }

        // obsługa przycisku wyjścia z programu
        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // wybór bazy danych pracowników
        private void button_workers_Click(object sender, RoutedEventArgs e)
        {
            ifWorkersClicked = true;
            ifCarsClicked = false;
            ifClientsClicked = false;
            button_cars.Visibility = Visibility.Collapsed;
            button_workers.Visibility = Visibility.Collapsed;
            button_clients.Visibility = Visibility.Collapsed;
            button_back.Visibility = Visibility.Visible;
            button_add.Visibility = Visibility.Visible;
            button_edit.Visibility = Visibility.Visible;
            button_remove.Visibility = Visibility.Visible;
            button_show.Visibility = Visibility.Visible;
            category.Text = "Workers";
            category.Visibility = Visibility.Visible;
        }

        // wybór bazy danych samochodów
        private void button_cars_Click(object sender, RoutedEventArgs e)
        {
            ifWorkersClicked = false;
            ifCarsClicked = true;
            ifClientsClicked = false;
            button_cars.Visibility = Visibility.Collapsed;
            button_workers.Visibility = Visibility.Collapsed;
            button_clients.Visibility = Visibility.Collapsed;
            button_back.Visibility = Visibility.Visible;
            button_add.Visibility = Visibility.Visible;
            button_edit.Visibility = Visibility.Visible;
            button_remove.Visibility = Visibility.Visible;
            button_show.Visibility = Visibility.Visible;
            category.Text = "Cars";
            category.Visibility = Visibility.Visible;
        }

        // wybór bazy danych klientów
        private void button_clients_Click(object sender, RoutedEventArgs e)
        {
            ifWorkersClicked = false;
            ifCarsClicked = false;
            ifClientsClicked = true;
            button_cars.Visibility = Visibility.Collapsed;
            button_workers.Visibility = Visibility.Collapsed;
            button_clients.Visibility = Visibility.Collapsed;
            button_back.Visibility = Visibility.Visible;
            button_add.Visibility = Visibility.Visible;
            button_edit.Visibility = Visibility.Visible;
            button_remove.Visibility = Visibility.Visible;
            button_show.Visibility = Visibility.Visible;
            category.Text = "Clients";
            category.Visibility = Visibility.Visible;
        }

        // przycisk obsługujący dodanie rekordu do wcześniej wybranej bazy danych
        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            ifAddClicked = true;
            ifActionClicked = true;
            button_add.Visibility = Visibility.Collapsed;
            button_edit.Visibility = Visibility.Collapsed;
            button_remove.Visibility = Visibility.Collapsed;
            button_show.Visibility = Visibility.Collapsed;
            textBox1.Visibility = Visibility.Visible;
            textBox2.Visibility = Visibility.Visible;
            textBox3.Visibility = Visibility.Visible;
            textBox4.Visibility = Visibility.Visible;
            textBox5.Visibility = Visibility.Visible;
            textBox6.Visibility = Visibility.Visible;
            textBox7.Visibility = Visibility.Visible;
            textBox8.Visibility = Visibility.Visible;
            button_confirm.Visibility = Visibility.Visible;
            category.Visibility = Visibility.Visible;

            // w zależności od wybranej wcześniej bazy danych textboxy przyjmują inne dane
            if (ifWorkersClicked == true)
            {
                category.Text = "Add a worker";
                textBox1.Watermark = "first name";
                textBox2.Watermark = "surname";
                textBox3.Watermark = "date of birth YYYY-MM-DD";
                textBox4.Watermark = "address";
                textBox5.Watermark = "salary";
                textBox6.Watermark = "date of engagement YYYY-MM-DD";
                textBox7.Watermark = "phone number";
                textBox8.Watermark = "e-mail address";
            }
            if (ifCarsClicked == true)
            {
                category.Text = "Add a car";
                textBox1.Watermark = "model";
                textBox2.Watermark = "year of production";
                textBox3.Watermark = "equipment";
                textBox4.Watermark = "VIN number";
                textBox5.Watermark = "mileage (type 0 if car is new)";
                textBox6.Watermark = "engine";
                textBox7.Watermark = "horsepower";
                textBox8.Watermark = "color";
            }
            if (ifClientsClicked == true)
            {
                category.Text = "Add a client";
                textBox1.Watermark = "first name";
                textBox2.Watermark = "surname";
                textBox3.Watermark = "date of birth YYYY-MM-DD";
                textBox4.Watermark = "address";
                textBox5.Watermark = "what was bought";
                textBox6.Watermark = "date of purchase";
                textBox7.Watermark = "phone number";
                textBox8.Watermark = "e-mail address";
            }
        }

        // obsługa przycisku usunięcia rekordu z bazy danych, poprzez podanie ID rekordu w konkretnej bazie
        private void button_remove_Click(object sender, RoutedEventArgs e)
        {
            ifRemoveClicked = true;
            ifActionClicked = true;
            button_add.Visibility = Visibility.Collapsed;
            button_edit.Visibility = Visibility.Collapsed;
            button_remove.Visibility = Visibility.Collapsed;
            button_show.Visibility = Visibility.Collapsed;
            textBox1.Visibility = Visibility.Visible;
            button_confirm.Visibility = Visibility.Visible;
            category.Visibility = Visibility.Visible;
            if (ifWorkersClicked == true)
            {
                category.Text = "Remove a worker";
                textBox1.Watermark = "type the employee ID";
            }
            if (ifCarsClicked == true)
            {
                category.Text = "Remove a car";
                textBox1.Watermark = "type the car ID";
            }
            if (ifClientsClicked == true)
            {
                category.Text = "Remove a client";
                textBox1.Watermark = "type the client ID";
            }
        }

        // obsługa edycji rekordu w bazie danych
        private void button_edit_Click(object sender, RoutedEventArgs e)
        {
            ifEditClicked = true;
            ifActionClicked = true;
            button_add.Visibility = Visibility.Collapsed;
            button_edit.Visibility = Visibility.Collapsed;
            button_remove.Visibility = Visibility.Collapsed;
            button_show.Visibility = Visibility.Collapsed;
            button_load.Visibility = Visibility.Visible;
            button_confirm.Visibility = Visibility.Visible;
            category.Visibility = Visibility.Visible;
            textBox1.Visibility = Visibility.Visible;
            textBox2.Visibility = Visibility.Visible;
            textBox3.Visibility = Visibility.Visible;
            textBox4.Visibility = Visibility.Visible;
            textBox5.Visibility = Visibility.Visible;
            textBox6.Visibility = Visibility.Visible;
            textBox7.Visibility = Visibility.Visible;
            textBox8.Visibility = Visibility.Visible;
            textBox9.Visibility = Visibility.Visible;
            if (ifWorkersClicked == true)
            {
                category.Text = "Edit a worker";
                textBox1.Watermark = "first name";
                textBox2.Watermark = "surname";
                textBox3.Watermark = "date of birth YYYY-MM-DD";
                textBox4.Watermark = "address";
                textBox5.Watermark = "salary";
                textBox6.Watermark = "date of engagement YYYY-MM-DD";
                textBox7.Watermark = "phone number";
                textBox8.Watermark = "e-mail address";
                textBox9.Watermark = "type the employee ID";
            }
            if (ifCarsClicked == true)
            {
                category.Text = "Edit a car";
                textBox1.Watermark = "model";
                textBox2.Watermark = "year of production";
                textBox3.Watermark = "equipment";
                textBox4.Watermark = "VIN number";
                textBox5.Watermark = "mileage (type 0 if car is new)";
                textBox6.Watermark = "engine";
                textBox7.Watermark = "horsepower";
                textBox8.Watermark = "color";
                textBox9.Watermark = "type the car ID";
            }
            if (ifClientsClicked == true)
            {
                category.Text = "Edit a client";
                textBox1.Watermark = "first name";
                textBox2.Watermark = "surname";
                textBox3.Watermark = "date of birth YYYY-MM-DD";
                textBox4.Watermark = "address";
                textBox5.Watermark = "what was bought";
                textBox6.Watermark = "date of purchase YYYY-MM-DD";
                textBox7.Watermark = "phone number";
                textBox8.Watermark = "e-mail address";
                textBox9.Watermark = "type the client ID";
            }

        }

        // obsługa wyświetlenia konkretnej bazy danych
        private void button_show_Click(object sender, RoutedEventArgs e)
        {
            ifActionClicked = true;
            button_add.Visibility = Visibility.Collapsed;
            button_edit.Visibility = Visibility.Collapsed;
            button_remove.Visibility = Visibility.Collapsed;
            button_show.Visibility = Visibility.Collapsed;
            category.Visibility = Visibility.Visible;
            textBox10.Visibility = Visibility.Visible;

            if (ifWorkersClicked == true)
            {
                View_workers_database.Visibility = Visibility.Visible;
                category.Text = "Workers database";
                DataTable tempDT = Workers.ShowWorkers();
                View_workers_database.ItemsSource = tempDT.DefaultView;
                textBox10.Watermark = "type the surname to find a worker and click enter";
            }
            if (ifCarsClicked == true)
            {
                View_cars_database.Visibility = Visibility.Visible;
                category.Text = "Cars database";
                DataTable tempDT = Cars.ShowCars();
                View_cars_database.ItemsSource = tempDT.DefaultView;
                textBox10.Watermark = "type the VIN to find a car and click enter";
            }
            if (ifClientsClicked == true)
            {
                View_clients_database.Visibility = Visibility.Visible;
                category.Text = "Clients database";
                DataTable tempDT = Clients.ShowClients();
                View_clients_database.ItemsSource = tempDT.DefaultView;
                textBox10.Watermark = "type the surname to find a client and click enter";
            }
        }

        // obsługa przycisku wstecz
        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            button_cars.Visibility = Visibility.Visible;
            button_workers.Visibility = Visibility.Visible;
            button_clients.Visibility = Visibility.Visible;
            button_back.Visibility = Visibility.Collapsed;
            category.Visibility = Visibility.Collapsed;
            button_add.Visibility = Visibility.Collapsed;
            button_edit.Visibility = Visibility.Collapsed;
            button_remove.Visibility = Visibility.Collapsed;
            button_show.Visibility = Visibility.Collapsed;
            button_load.Visibility = Visibility.Collapsed;
            textBox1.Visibility = Visibility.Collapsed;
            textBox2.Visibility = Visibility.Collapsed;
            textBox3.Visibility = Visibility.Collapsed;
            textBox4.Visibility = Visibility.Collapsed;
            textBox5.Visibility = Visibility.Collapsed;
            textBox6.Visibility = Visibility.Collapsed;
            textBox7.Visibility = Visibility.Collapsed;
            textBox8.Visibility = Visibility.Collapsed;
            textBox9.Visibility = Visibility.Collapsed;
            textBox10.Visibility = Visibility.Collapsed;
            button_confirm.Visibility = Visibility.Collapsed;
            View_workers_database.Visibility = Visibility.Collapsed;
            View_cars_database.Visibility = Visibility.Collapsed;
            View_clients_database.Visibility = Visibility.Collapsed;

            if (ifActionClicked == true)
            {
                button_back.Visibility = Visibility.Visible;
                button_cars.Visibility = Visibility.Collapsed;
                button_workers.Visibility = Visibility.Collapsed;
                button_clients.Visibility = Visibility.Collapsed;
                button_add.Visibility = Visibility.Visible;
                button_edit.Visibility = Visibility.Visible;
                button_remove.Visibility = Visibility.Visible;
                button_show.Visibility = Visibility.Visible;
                category.Visibility = Visibility.Visible;
                if (ifWorkersClicked == true)
                {
                    category.Text = "Workers";
                }
                if (ifCarsClicked == true)
                {
                    category.Text = "Cars";
                }
                if (ifClientsClicked == true)
                {
                    category.Text = "Clients";
                }
                ifActionClicked = false;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
            }
            ifAddClicked = false;
            ifRemoveClicked = false;
            ifEditClicked = false;
        }

        // obsługa przycisku potwierdzającego wykonanie operacji i odpowiednie działanie na konkretnej bazie danych
        private void button_confirm_Click(object sender, RoutedEventArgs e)
        {
            int salary;
            int phoneNr;
            int id;
            int yearofprod;
            int miles;
            int horses;
            
            // dla pracowników
            if (ifAddClicked == true && ifWorkersClicked == true)
            {
                if (Int32.TryParse(textBox5.Text, out salary) && Int32.TryParse(textBox7.Text, out phoneNr))
                    Workers.AddWorker(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, salary, textBox6.Text, phoneNr, textBox8.Text);
                if (Workers.ifCorrect)
                {
                    MessageBox.Show("data inserted", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    Workers.ifCorrect = false;
                }
                else
                    MessageBox.Show("something went wrong...", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ifRemoveClicked == true && ifWorkersClicked == true)
            {
                if (Int32.TryParse(textBox1.Text, out id))
                    Workers.RemoveWorker(id);
                if (Workers.ifCorrect)
                {
                    MessageBox.Show("data removed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    Workers.ifCorrect = false;
                }
                else
                    MessageBox.Show("something went wrong...", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ifEditClicked == true && ifWorkersClicked == true)
            {
                if (Int32.TryParse(textBox5.Text, out salary) && Int32.TryParse(textBox7.Text, out phoneNr) && Int32.TryParse(textBox9.Text, out id))
                    Workers.EditWorker(id, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, salary, textBox6.Text, phoneNr, textBox8.Text);
                if (Workers.ifCorrect)
                {
                    MessageBox.Show("data edited", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    Workers.ifCorrect = false;
                }
                else
                    MessageBox.Show("something went wrong...", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            //dla klientów
            if (ifAddClicked == true && ifClientsClicked == true)
            {
                if (Int32.TryParse(textBox7.Text, out phoneNr))
                    Clients.AddClient(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, phoneNr, textBox8.Text);
                if (Clients.ifCorrect)
                {
                    MessageBox.Show("data inserted", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    Clients.ifCorrect = false;
                }
                else
                    MessageBox.Show("something went wrong...", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ifRemoveClicked == true && ifClientsClicked == true)
            {
                if (Int32.TryParse(textBox1.Text, out id))
                    Clients.RemoveClient(id);
                if (Clients.ifCorrect)
                {
                    MessageBox.Show("data removed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    Clients.ifCorrect = false;
                }
                else
                    MessageBox.Show("something went wrong...", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ifEditClicked == true && ifClientsClicked == true)
            {
                if (Int32.TryParse(textBox7.Text, out phoneNr) && Int32.TryParse(textBox9.Text, out id))
                    Clients.EditClient(id, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, phoneNr, textBox8.Text);
                if (Clients.ifCorrect)
                {
                    MessageBox.Show("data edited", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    Clients.ifCorrect = false;
                }
                else
                    MessageBox.Show("something went wrong...", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // dla samochodów
            if (ifAddClicked == true && ifCarsClicked == true)
            {
                if (Int32.TryParse(textBox2.Text, out yearofprod) && Int32.TryParse(textBox5.Text, out miles) && Int32.TryParse(textBox7.Text, out horses))
                    Cars.AddCar(textBox1.Text, yearofprod, textBox3.Text, textBox4.Text, miles, textBox6.Text, horses, textBox8.Text);
                if (Cars.ifCorrect)
                {
                    MessageBox.Show("data inserted", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    Cars.ifCorrect = false;
                }
                else
                    MessageBox.Show("something went wrong...", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ifRemoveClicked == true && ifCarsClicked == true)
            {
                if (Int32.TryParse(textBox1.Text, out id))
                    Cars.RemoveCar(Int32.Parse(textBox1.Text));
                if (Cars.ifCorrect)
                {
                    MessageBox.Show("data removed", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    Cars.ifCorrect = false;
                }
                else
                    MessageBox.Show("something went wrong...", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ifEditClicked == true && ifCarsClicked == true)
            {
                if (Int32.TryParse(textBox9.Text, out id) && Int32.TryParse(textBox2.Text, out yearofprod) && Int32.TryParse(textBox5.Text, out miles) && Int32.TryParse(textBox7.Text, out horses))
                    Cars.EditCar(id, textBox1.Text, yearofprod, textBox3.Text, textBox4.Text, miles, textBox6.Text, horses, textBox8.Text);
                if (Cars.ifCorrect)
                {
                    MessageBox.Show("data edited", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    Cars.ifCorrect = false;
                }
                else
                    MessageBox.Show("something went wrong...", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        // funkcja akceptacji zawartości textboxa, potrzebnej do wyszukiwania jej w bazie danych
        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (ifWorkersClicked == true && textBox10.Text != "")
                {
                    DataTable tempDT = Workers.FilterWorkers(textBox10.Text);
                    View_workers_database.ItemsSource = tempDT.DefaultView;
                }
                else if (ifWorkersClicked == true && textBox10.Text == "")
                {
                    DataTable tempDT = Workers.ShowWorkers();
                    View_workers_database.ItemsSource = tempDT.DefaultView;
                }
                if (ifClientsClicked == true && textBox10.Text != "")
                {
                    DataTable tempDT = Clients.FilterClients(textBox10.Text);
                    View_clients_database.ItemsSource = tempDT.DefaultView;
                }
                else if (ifClientsClicked == true && textBox10.Text == "")
                {
                    DataTable tempDT = Clients.ShowClients();
                    View_clients_database.ItemsSource = tempDT.DefaultView;
                }
                if (ifCarsClicked == true && textBox10.Text != "")
                {
                    DataTable tempDT = Cars.FilterCars(textBox10.Text);
                    View_cars_database.ItemsSource = tempDT.DefaultView;
                }
                else if (ifCarsClicked == true && textBox10.Text == "")
                {
                    DataTable tempDT = Cars.ShowCars();
                    View_cars_database.ItemsSource = tempDT.DefaultView;
                }
            }
        }

        // obsługa przycisku load, który przy edytowaniu i wpisaniu ID ładuje dane danej osoby do edycji
        private void button_load_Click(object sender, RoutedEventArgs e)
        {
            if (ifWorkersClicked && ifEditClicked)
            {
                Workers.loadData(Int32.Parse(textBox9.Text));
                textBox1.Text = Workers.f_name;
                textBox2.Text = Workers.l_name;
                textBox3.MaxLength = 10;
                textBox3.Text = Workers.dateofbirth;
                textBox4.Text = Workers.address;
                textBox5.Text = Workers.salary.ToString();
                textBox6.MaxLength = 10;
                textBox6.Text = Workers.dateofengagement;
                textBox7.Text = Workers.phonenumber.ToString();
                textBox8.Text = Workers.email;
            }
            if (ifClientsClicked && ifEditClicked)
            {
                Clients.loadData(Int32.Parse(textBox9.Text));
                textBox1.Text = Clients.f_name;
                textBox2.Text = Clients.l_name;
                textBox3.MaxLength = 10;
                textBox3.Text = Clients.dateofbirth;
                textBox4.Text = Clients.address;
                textBox5.Text = Clients.productbought;
                textBox6.MaxLength = 10;
                textBox6.Text = Clients.dateofpurchase;
                textBox7.Text = Clients.phonenumber.ToString();
                textBox8.Text = Clients.email;
            }
            if (ifCarsClicked && ifEditClicked)
            {
                Cars.loadData(Int32.Parse(textBox9.Text));
                textBox1.Text = Cars.model;
                textBox2.Text = Cars.yearofprod.ToString();
                textBox3.Text = Cars.eq;
                textBox4.Text = Cars.vin;
                textBox5.Text = Cars.mileage.ToString();
                textBox6.Text = Cars.engine;
                textBox7.Text = Cars.horsepow.ToString();
                textBox8.Text = Cars.color;
            }
        }
    }
}
