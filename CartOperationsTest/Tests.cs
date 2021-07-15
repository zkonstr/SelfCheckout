using System;
using NUnit.Framework;
using SelfCheckuot.Shop;

namespace CartOperationsTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestAddOne()
        {
            var cart = new Cart();
            cart.Add(new Product(1000, "testProduct", new decimal(1.2)));
            Assert.AreEqual(1.2,cart.Sum);
        }

        [Test]
        public void TestAddMany()
        {
            var cart = new Cart();
            cart.Add(new Product(1000, "testProduct1", new decimal(1.2)));
            cart.Add(new Product(1000, "testProduct2", new decimal(2.5)));
            Assert.AreEqual(3.7,cart.Sum);
        }

        [Test]
        public void TestDeleteOne()
        {
            var cart = new Cart();
            cart.Add(new Product(1000, "testProduct1", new decimal(1.2)));
            cart.Add(new Product(1000, "testProduct2", new decimal(2.5)));
            cart.Delete(1);
            Assert.AreEqual(1.2,cart.Sum);
        }
        
        [Test]
        public void TestDeleteMany()
        {
            var cart = new Cart();
            cart.Add(new Product(1000, "testProduct1", new decimal(1.2)));
            cart.Add(new Product(1000, "testProduct2", new decimal(2.5)));
            cart.Delete(0);
            cart.Delete(1);
            Assert.AreEqual(0,cart.Sum);
        }
        
        [Test]
        public void TestDeleteEmpty()
        {
            var cart = new Cart();
            try
            {
                cart.Delete(0);
                Assert.Fail();
            }
            catch
            {
                Assert.Pass();
            }
        }
        
        [Test]
        
        public void TestDeleteNegative()
        {
            var cart = new Cart();
            cart.Add(new Product(1000, "testProduct1", new decimal(1.2)));
            cart.Add(new Product(1000, "testProduct2", new decimal(2.5)));
            try
            {
                cart.Delete(-1);
                Assert.Fail();
            }
            catch
            {
                Assert.Pass();
            }
        }
        
    }
}