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
using TRPZ.ViewModels;


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
        public LoginViewModel loginViewModel;

        public LoginWindow()
        {
            InitializeComponent();
            db = new DatebaseAppContext();
            loginViewModel = new LoginViewModel(db, this);
            this.DataContext = loginViewModel;
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

        private void Button_Click_SignIn(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
