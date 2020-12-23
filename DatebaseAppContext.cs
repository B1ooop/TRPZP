namespace TRPZ
{
    using System.Data.Entity;
    using TRPZ.Models;

    public class DatebaseAppContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }


        public DatebaseAppContext() : base("DefaultConnection")
        {
        }
    }
}
