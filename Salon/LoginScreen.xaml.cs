using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Salon
{
    ////login i hasło: ("akademia", "p@ss123");
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        // obsługa przycisku potwierdzającego logowanie
        private void button_confirm_Click(object sender, RoutedEventArgs e)
        {
            // ustawienie kursora oczekiwania podczas łączenia z bazą
            this.Cursor = Cursors.Wait;

            // połączenie z bazą danych poprzez użycie funkcji z klasy dbConnect
            dbConnect.connect(textBox_username.Text, passwordBox.Password);

            // jeśli połączony (zgodne login i hasło), to wyświetl odpowiedniego messageboxa i wyświetl główne okno
            if (dbConnect.ifConnected)
            {
                MessageBox.Show("Connected");
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }

            // jeśli nie, to również odpowiedni messagebox, czyszczenie textboxów i możliwość powtórnego wpisania
            else
            {
                MessageBox.Show("Access denied","", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox_username.Clear();
                passwordBox.Clear();
                this.Cursor = Cursors.Arrow;
            }
        }
    }
}
