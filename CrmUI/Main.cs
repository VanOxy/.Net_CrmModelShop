using CrmBL.Model;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Main : Form
    {
        public CrmContext db;

        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogOfProducts = new Catalog<Product>(db.Products, db);
            catalogOfProducts.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogOfSellers = new Catalog<Seller>(db.Sellers, db);
            catalogOfSellers.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogOfCustomers = new Catalog<Customer>(db.Customers, db);
            catalogOfCustomers.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogOfChecks = new Catalog<Check>(db.Checks, db);
            catalogOfChecks.Show();
        }

        private void SellerAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new SellerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(form.Seller);
                db.SaveChanges();
            }
        }

        private void CustomerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(form.Customer);
                db.SaveChanges();
            }
        }

        private void ProductAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(form.Product);
                db.SaveChanges();
            }
        }
    }
}