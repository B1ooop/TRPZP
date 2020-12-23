namespace TRPZ.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public int Customer_id { get; private set; }
        public string Products { get; private set; }
        public float Price { get; private set; } // Active, Decline, Completed

        public Order(int customer_id, string products, float price)
        {
            this.Customer_id = customer_id;
            this.Products = products;
            this.Price = price;
        }

        public Order() { }
    }
}
