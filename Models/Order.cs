using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPZ.Models
{
    public class Order
    {
        public int id { get; private set; }
        public int customer_id { get; private set; }
        public string products { get; private set; }
        public float price { get; private set; } // Active, Decline, Completed

        public Order(int customer_id, string products, float price)
        {
            this.customer_id = customer_id;
            this.products = products;
            this.price = price;
        }

        public Order(){}
    }
}
