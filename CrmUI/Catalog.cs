using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Catalog<T> : Form where T : class
    {
        public Catalog(DbSet<T> dataSet)
        {
            InitializeComponent();
            dataGridView.DataSource = dataSet.Local.ToBindingList();
        }
    }
}