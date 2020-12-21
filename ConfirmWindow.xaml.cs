using System.Windows;
using TRPZ.Models;

namespace TRPZ
{
    /// <summary>
    /// Логика взаимодействия для ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {
        readonly Order currentOrder;
        public string[] orderedProducts;
        private readonly DatebaseAppContext db;

        public ConfirmWindow()
        {
            InitializeComponent();
            db = new DatebaseAppContext();
            currentOrder = OrderWindow.GetOrder();
            orderedProducts = currentOrder.Products.Split(' ');
            productList.Text = "Order № " + currentOrder.Id + "\nContains:\n" + string.Join("\n", orderedProducts);
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
                if (order.Id == currentOrder.Id)
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
