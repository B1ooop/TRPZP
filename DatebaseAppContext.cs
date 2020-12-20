using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;
using TRPZ.Models;

namespace TRPZ
{
    public class DatebaseAppContext: DbContext
    {
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }


        public DatebaseAppContext(): base("DefaultConnection")
        {
            
        }
    }
}
