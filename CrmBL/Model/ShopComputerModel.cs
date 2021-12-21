using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var customers = generator.GetNewCustomers(10);

            var carts = new Queue<Cart>();

            foreach (var customer in customers)
            {
                var cart = new Cart(customer);

                foreach (var prod in generator.GetRandomProducts(10, 30))
                {
                    cart.Add(prod);
                }
                carts.Enqueue(cart);
            }

            while(carts.Count > 0)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];
                cash.Enqueue(carts.Dequeue());
            }

            while (true)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];
                cash.Dequeue();
            }
        }
    }
}