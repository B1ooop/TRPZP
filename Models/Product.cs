namespace TRPZ.Models
{
    using System;

    public class Product
    {
        public int Id { get; private set; }
        public string ProductName { get; private set; }
        public int Price { get; private set; }

        public Product(String productName, int price)
        {
            this.ProductName = productName;
            this.Price = price;

        }

        public Product() { }
    }
}
