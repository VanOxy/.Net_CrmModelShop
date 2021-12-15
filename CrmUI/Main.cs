using CrmBL.Model;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Main : Form
    {
        private CrmContext db;

        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogOfProducts = new Catalog<Product>(db.Products);
            catalogOfProducts.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogOfSellers = new Catalog<Seller>(db.Sellers);
            catalogOfSellers.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogOfCustomers = new Catalog<Customer>(db.Customers);
            catalogOfCustomers.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogOfChecks = new Catalog<Check>(db.Checks);
            catalogOfChecks.Show();
        }

        private void SellerAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
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
        }
    }
}