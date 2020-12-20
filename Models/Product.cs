using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPZ.Models
{
    public class Product
    {       
        public int id { get; private set; }
        public string productName { get; private set; }
        public int price { get; private set; }

        public Product(String productName, int price)
        {
            this.productName = productName;
            this.price = price;

        }

        public Product() { }
    }
}
