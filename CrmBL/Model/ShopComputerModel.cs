using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class ShopComputerModel
    {
        private Generator generator = new Generator();
        private Random rnd = new Random();
        public List<CashDesk> CashDesks { get; set; } = new();
        public List<Cart> Carts { get; set; } = new();
        public List<Check> Cheks { get; set; } = new();
        public List<Sell> Sells { get; set; } = new();
        public Queue<Seller> Sellers { get; set; } = new();
        public int CustomerSpeed { get; set; } = 100;
        public int CashDeskSpeed { get; set; } = 100;

        private bool isWorking = false;

        public ShopComputerModel()
        {
            var sellers = generator.GetNewSellers(20);
            generator.GetNewProducts(1000);
            generator.GetNewCustomers(100);

            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }

        public void Start()
        {
            isWorking = true;
            Task.Run(() => CreateCarts(10, CustomerSpeed));

            var cashDeskTasks = CashDesks.Select(c => new Task(() => CashDeskWork(c, CashDeskSpeed)));
            foreach (var task in cashDeskTasks)
            {
                task.Start();
            }
        }

        public void Stop()
        {
            isWorking = false;
        }

        private void CashDeskWork(CashDesk cashDesk, int sleep)
        {
            while (isWorking)
            {
                if (cashDesk.Count > 0)
                {
                    cashDesk.Dequeue();
                    Thread.Sleep(sleep);
                }
            }
        }

        private void CreateCarts(int customerCounts, int sleep)
        {
            while (isWorking)
            {
                var customers = generator.GetNewCustomers(customerCounts);

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);

                    foreach (var product in generator.GetRandomProducts(10, 30))
                    {
                        cart.Add(product);
                    }

                    var cash = CashDesks[rnd.Next(CashDesks.Count)];
                    cash.Enqueue(cart);
                }

                Thread.Sleep(sleep);
            }
        }
    }
}