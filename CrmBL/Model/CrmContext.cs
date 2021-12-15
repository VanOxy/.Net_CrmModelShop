using System.Configuration;
using System.Data.Entity;

namespace CrmBL.Model
{
    public class CrmContext : DbContext
    {
        public CrmContext() : base("Data Source=DESKTOP-PBOLLA9;Initial Catalog=CRM;Integrated Security=True;")
        {
        }

        public DbSet<Check> Checks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }
}