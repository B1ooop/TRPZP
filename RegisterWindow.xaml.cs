namespace TRPZ
{
    using System.Windows;
    using System.Windows.Media;
    using TRPZ.Models;

    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        DatebaseAppContext db;
        public static string transferLogin;

        public RegisterWindow()
        {
            this.InitializeComponent();
            this.db = new DatebaseAppContext();
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
            string inputLogin = this.login.Text.Trim();
            string inputPassword = this.password.Text.Trim();
            string inputEmail = this.email.Text.Trim();
            string inputPhone = this.phone.Text.Trim();

            // Ultra very bad validation
            if (inputLogin.Length < 1 || inputPassword.Length < 1 || inputEmail.Length < 1 || inputPhone.Length < 1)
            {
                if (inputLogin.Length < 1)
                {
                    this.login.Background = Brushes.DarkRed;
                }
                else
                {
                    this.login.Background = Brushes.Transparent;
                }
                if (inputPassword.Length < 1)
                {
                    this.password.Background = Brushes.DarkRed;
                }
                else
                {
                    this.password.Background = Brushes.Transparent;
                }
                if (inputEmail.Length < 1)
                {
                    this.email.Background = Brushes.DarkRed;
                }
                else
                {
                    this.email.Background = Brushes.Transparent;
                }
                if (inputPhone.Length < 1)
                {
                    this.phone.Background = Brushes.DarkRed;
                }
                else
                {
                    this.phone.Background = Brushes.Transparent;
                }
            }
            else
            {
                Customer customer = new Customer(inputLogin, inputPassword, inputEmail, inputPhone);
                this.db.Customers.Add(customer);
                this.db.SaveChanges();
                inputLogin = customer.login;

                OrderWindow owReg = new OrderWindow();
                owReg.Show();
                this.Hide();
            }
        }
    }
}
