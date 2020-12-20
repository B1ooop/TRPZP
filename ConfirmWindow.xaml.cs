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
    /// Логика взаимодействия для ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {
        Order currentOrder;
        public string[] orderedProducts;
        private DatebaseAppContext db;

        public ConfirmWindow()
        {
            InitializeComponent();
            db = new DatebaseAppContext();
            currentOrder = OrderWindow.getOrder();
            orderedProducts = currentOrder.products.Split(' ');
            productList.Text ="Order № " + currentOrder.id + "\nContains:\n" +  string.Join("\n", orderedProducts);
        }

     

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your order was confirmed!");
            Application.Current.Shutdown();
        }

        private void Button_Click_RemoveOrder(object sender, RoutedEventArgs e)
        {
            foreach (Order order in db.Orders)
            {
                if (order.id == currentOrder.id)
                {
                    db.Orders.Remove(order);
                    db.SaveChanges();
                    break;
                }
            }
            MessageBox.Show("Your order was removed!");
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }
    }
}
