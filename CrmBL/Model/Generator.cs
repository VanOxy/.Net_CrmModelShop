using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Generator
    {
        private Random rnd = new();
        public List<Customer> Customers { get; set; } = new();
        public List<Product> Products { get; set; } = new();
        public List<Seller> Sellers { get; set; } = new();

        public List<Customer> GetNewCustomers(int count)
        {
            var results = new List<Customer>();

            for (int i = 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    CustomerId = Customers.Count,
                    Name = GetRandomText()
                };
                Customers.Add(customer);
                results.Add(customer);
            }
            return results;
        }

        public List<Seller> GetNewSellers(int count)
        {
            var results = new List<Seller>();

            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    SellerId = Sellers.Count,
                    Name = GetRandomText()
                };
                Sellers.Add(seller);
                results.Add(seller);
            }
            return results;
        }

        public List<Product> GetNewProducts(int count)
        {
            var results = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    ProductId = Products.Count,
                    Name = GetRandomText(),
                    Count = rnd.Next(0, 100),
                    Price = Convert.ToDecimal(rnd.Next(5, 100000) + rnd.NextDouble())
                };
                Products.Add(product);
                results.Add(product);
            }
            return results;
        }

        public List<Product> GetRandomProducts(int min, int max)
        {
            var result = new List<Product>();
            var count = rnd.Next(min, max);
            for (int i = 0; i < count; i++)
            {
                result.Add(Products[rnd.Next(Products.Count - 1)]);
            }
            return result;
        }

        private static string GetRandomText()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }
    }
}