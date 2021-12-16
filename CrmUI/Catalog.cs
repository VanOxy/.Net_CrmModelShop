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
        private readonly ObservableCollection<T> viewData;

        public Catalog(DbSet<T> dataSet)
        {
            InitializeComponent();
            viewData = new ObservableCollection<T>();

            var querry = from c in dataSet select c;
            var data = querry.ToList();
            foreach (var item in data)
                viewData.Add(item);

            dataGridView.DataSource = viewData;
            //dataGridView.DataSource = dataSet.Local.ToBindingList();
        }
    }
}