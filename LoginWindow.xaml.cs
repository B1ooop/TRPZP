using System.Windows;
using TRPZ.ViewModels;

namespace TRPZ
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        readonly DatebaseAppContext db;
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
        { }
    }
}
