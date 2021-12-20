using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;

using CrmBL.Model;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Catalog<T> : Form where T : class
    {
        private CrmContext db;
        private DbSet<T> dataSet;

        public Catalog(DbSet<T> dataSet, CrmContext db)
        {
            InitializeComponent();
            this.dataSet = dataSet;
            this.db = db;
            this.dataSet.Load();
            dataGridView.DataSource = this.dataSet.Local.ToBindingList();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {
                var form = new ProductForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db.Products.Add(form.Product);
                    db.SaveChanges();
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var form = new SellerForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db.Sellers.Add(form.Seller);
                    db.SaveChanges();
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                var form = new CustomerForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db.Customers.Add(form.Customer);
                    db.SaveChanges();
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView.CurrentCell.RowIndex;
            var id = dataGridView[0, selectedRow].Value;

            if (typeof(T) == typeof(Product))
            {
                var product = dataSet.Find(id) as Product;
                if (product != null)
                {
                    var form = new ProductForm(product);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var seller = dataSet.Find(id) as Seller;
                if (seller != null)
                {
                    var form = new SellerForm(seller);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        seller = form.Seller;
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                var customer = dataSet.Find(id) as Customer;
                if (customer != null)
                {
                    var form = new CustomerForm(customer);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        customer = form.Customer;
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
        }
    }
}