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
using TRPZ.Models;


namespace TRPZ
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DatebaseAppContext db;
        public string inputLogin;
        public string inputPassword;
        public static string transferLogin;
        public LoginWindow()
        {
            InitializeComponent();
            db = new DatebaseAppContext();
        }

        public static string getLogin()
        {
            return transferLogin;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

        private void Button_Click_SignIn(object sender, RoutedEventArgs e)
        {
            {
                bool invalidData = false;
                List<Customer> customers = db.Customers.ToList();
                inputLogin = login.Text.Trim();
                inputPassword = password.Text.Trim();

                // Ultra very bad validation
                if (inputLogin.Length < 1 || inputPassword.Length < 1)
                {
                    if (inputLogin.Length < 1)
                    {
                        login.Background = Brushes.DarkRed;
                    }
                    else
                    {
                        login.Background = Brushes.Transparent;
                    }
                    if (inputPassword.Length < 1)
                    {
                        password.Background = Brushes.DarkRed;
                    }
                    else
                    {
                        password.Background = Brushes.Transparent;
                    }
                }
                else
                {
                    foreach (Customer customer in customers)
                    {
                        if (customer.login == inputLogin && customer.password == inputPassword)
                        {
                            transferLogin = customer.login;
                            invalidData = false;
                            OrderWindow owLog = new OrderWindow();
                            owLog.Show();
                            this.Hide();
                            break;
                        }
                        invalidData = true;
                    }
                    if (invalidData)
                    {
                        MessageBox.Show("Invalid Login or Password");
                    }
                }
            }
        }
    }
}
