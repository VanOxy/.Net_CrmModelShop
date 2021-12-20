using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            // arrange
            var customer = new Customer()
            {
                CustomerId = 1,
                Name = "testUser"
            };
            var product = new Product()
            {
                ProductId = 1,
                Name = "pr1",
                Price = 100,
                Count = 10
            };
            var product2 = new Product()
            {
                ProductId = 2,
                Name = "prod2",
                Price = 200,
                Count = 20
            };
            var cart = new Cart(customer);
            //--------------------------
            var expectedResults = new List<Product>()
            {
                product, product, product2
            };

            // act
            cart.Add(product);
            cart.Add(product);
            cart.Add(product2);

            var cartResult = cart.GetAll();

            // assert
            Assert.AreEqual(expectedResults.Count, cartResult.Count);
            for (int i = 0; i < expectedResults.Count; i++)
                Assert.AreEqual(expectedResults[i], cartResult[i]);
        }
    }
}