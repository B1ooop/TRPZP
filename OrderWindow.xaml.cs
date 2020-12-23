using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TRPZ.Commons;
using TRPZ.Models;

namespace TRPZ
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        readonly DatebaseAppContext db;
        string orderedProducts = "";
        float totalPrice = 0;
        readonly Customer currentCustomer;
        public static Order transferOrder;

        public static Order GetOrder()
        {
            return transferOrder;
        }
        public OrderWindow()
        {
            InitializeComponent();
            db = new DatebaseAppContext();

            // Пробросить поле из LoginWindow
            string currentCustomerlogin;
            if (LoginCommand.transferLogin != "")
            {
                currentCustomerlogin = LoginCommand.transferLogin;
            }
            else
            {
                currentCustomerlogin = RegisterWindow.getLogin();
            }


            // Вывести имя текущего пользователя
            List<Customer> customers = db.Customers.ToList();
            welcomeCustomer.Text = "Welcome, please choose products to order";
            foreach (Customer customer in customers)
            {
                if (customer.login == currentCustomerlogin)
                {
                    currentCustomer = customer;
                    welcomeCustomer.Text = "Welcome, " + customer.login + ", please choose products to order";
                }
            }
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            List<Product> pr = db.Products.ToList();

            if (milk.IsChecked == true)
            {
                orderedProducts += pr[0].ProductName + " ";
                totalPrice += pr[0].Price;
            }
            if (cheese.IsChecked == true)
            {
                orderedProducts += pr[1].ProductName + " ";
                totalPrice += pr[1].Price;
            }
            if (cottageCheese.IsChecked == true)
            {
                orderedProducts += pr[2].ProductName + " ";
                totalPrice += pr[2].Price;
            }
            if (potato.IsChecked == true)
            {
                orderedProducts += pr[3].ProductName + " ";
                totalPrice += pr[3].Price;
            }
            if (tomato.IsChecked == true)
            {
                orderedProducts += pr[4].ProductName + " ";
                totalPrice += pr[4].Price;
            }
            if (strawberry.IsChecked == true)
            {
                orderedProducts += pr[5].ProductName + " ";
                totalPrice += pr[5].Price;
            }

            Order order = new Order(currentCustomer.Id, orderedProducts, totalPrice);
            db.Orders.Add(order);
            db.SaveChanges();
            transferOrder = order;

            ConfirmWindow cw = new ConfirmWindow();
            cw.Show();
            this.Hide();
        }
    }
}
