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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        DatebaseAppContext db;
        string orderedProducts = "";
        float totalPrice = 0;
        Customer currentCustomer;
        public static Order transferOrder;

        public  static  Order getOrder()
        {
            return transferOrder;
        }
        public OrderWindow()
        {
            InitializeComponent();
            db = new DatebaseAppContext();

            //Пробросить поле из LoginWindow
            string currentCustomerlogin;
            if (LoginWindow.getLogin() != "")
            {
                currentCustomerlogin = LoginWindow.getLogin();
            }
            else
            {
                currentCustomerlogin = RegisterWindow.getLogin();
            }
           
            
            //Вывести имя текущего пользователя
            List<Customer> customers = db.Customers.ToList();
            welcomeCustomer.Text = "Welcome, please choose products to order" ;
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
                orderedProducts += pr[0].productName + " ";
                totalPrice += pr[0].price;
            }
            if (cheese.IsChecked == true)
            {
                orderedProducts += pr[1].productName + " ";
                totalPrice += pr[1].price;
            }
            if (cottageCheese.IsChecked == true)
            {
                orderedProducts += pr[2].productName + " ";
                totalPrice += pr[2].price;
            }
            if (potato.IsChecked == true)
            {
                orderedProducts += pr[3].productName + " ";
                totalPrice += pr[3].price;
            }
            if (tomato.IsChecked == true)
            {
                orderedProducts += pr[4].productName + " ";
                totalPrice += pr[4].price;
            }
            if (strawberry.IsChecked == true)
            {
                orderedProducts += pr[5].productName + " ";
                totalPrice += pr[5].price;
            }

            Order order = new Order(currentCustomer.id, orderedProducts, totalPrice);
            db.Orders.Add(order);
            db.SaveChanges();
            transferOrder = order;

            ConfirmWindow cw = new ConfirmWindow();
            cw.Show();
            this.Hide();
        }
    }
}
