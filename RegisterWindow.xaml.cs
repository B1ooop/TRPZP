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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        DatebaseAppContext db;
        public static string transferLogin;

        public RegisterWindow()
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

        private void Button_Click_SignUp(object sender, RoutedEventArgs e)
        {
           

            string inputLogin = login.Text.Trim();
            string inputPassword = password.Text.Trim();
            string inputEmail = email.Text.Trim();
            string inputPhone= phone.Text.Trim();

            // Ultra very bad validation
            if (inputLogin.Length < 1 || inputPassword.Length < 1 || inputEmail.Length < 1 || inputPhone.Length < 1)
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
                if (inputEmail.Length < 1)
                {
                    email.Background = Brushes.DarkRed;
                }
                else
                {
                    email.Background = Brushes.Transparent;
                }
                if (inputPhone.Length < 1)
                {
                    phone.Background = Brushes.DarkRed;
                }
                else
                {
                    phone.Background = Brushes.Transparent;
                }
            }
            else
            {
                Customer customer = new Customer(inputLogin, inputPassword, inputEmail, inputPhone);
                db.Customers.Add(customer);
                db.SaveChanges();
                inputLogin = customer.login;

                OrderWindow owReg = new OrderWindow();
                owReg.Show();
                this.Hide();
            }
        }
    } 
}
