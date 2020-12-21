using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using TRPZ.Models;


namespace TRPZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatebaseAppContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new DatebaseAppContext();
            db.Products.Add(new Product("Milk", 36));
            db.Products.Add(new Product("Cheese", 50));
            db.Products.Add(new Product("CottageCheese", 36));
            db.Products.Add(new Product("Potato", 18));
            db.Products.Add(new Product("Tomato", 42));
            db.Products.Add(new Product("Strawberry", 120));
            db.SaveChanges();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 400;
            animation.Duration = TimeSpan.FromSeconds(1);
            btnLogin.BeginAnimation(Button.WidthProperty, animation);
            btnPassword.BeginAnimation(Button.WidthProperty, animation);

        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Hide();
        }

        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.Show();
            this.Hide();
        }


    }


    public class Service
    {
        public List<Order> orders { get; private set; }
        public List<Customer> customers { get; private set; }

    }

}
