using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    internal class CashBoxView
    {
        private CashDesk cashDesk;
        public Label CashDeskName { get; set; }
        public NumericUpDown Price { get; set; }
        public ProgressBar QueueLenght { get; set; }
        public Label ExitCustomersCount { get; set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;

            CashDeskName = new Label();
            Price = new NumericUpDown();
            QueueLenght = new ProgressBar();
            ExitCustomersCount = new Label();

            var numUpDown = new NumericUpDown();

            CashDeskName.AutoSize = true;
            CashDeskName.Location = new System.Drawing.Point(x, y);
            CashDeskName.Name = "label" + number;
            CashDeskName.Size = new System.Drawing.Size(35, 13);
            CashDeskName.TabIndex = number;
            CashDeskName.Text = cashDesk.ToString();

            Price.Location = new System.Drawing.Point(x + 150, y);
            Price.Name = "numericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 10000000000000;

            QueueLenght.Location = new System.Drawing.Point(x + 280, y);
            QueueLenght.Maximum = cashDesk.MaxQueueLenght;
            QueueLenght.Name = "progressBar" + number;
            QueueLenght.Size = new System.Drawing.Size(125, 29);
            QueueLenght.TabIndex = number;
            QueueLenght.Value = 0;

            ExitCustomersCount.AutoSize = true;
            ExitCustomersCount.Location = new System.Drawing.Point(x + 450, y);
            ExitCustomersCount.Name = "ExitCustomers_lbl" + number;
            ExitCustomersCount.Size = new System.Drawing.Size(35, 13);
            ExitCustomersCount.TabIndex = number;
            ExitCustomersCount.Text = "";

            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            Price.Invoke((Action)delegate
            {
                Price.Value += e.Price;
                QueueLenght.Value = cashDesk.Count;
                ExitCustomersCount.Text = cashDesk.ExitCustomer.ToString();
            });
        }
    }
}