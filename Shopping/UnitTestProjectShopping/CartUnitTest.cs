using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DomainModels.Entities;
using Repository.Abstraction;
using Repository.Implementation;

namespace UnitTestProjectShopping
{
    [TestClass]
    public class CartUnitTest
    {
        ICartRepository cart;
        public  CartUnitTest()
        {
            cart = new CartRepository();
        }
        [TestMethod]
        public void ScenarioA()
        {
            cart.AddCart(1, "A", 50, 1);
            cart.AddCart(2, "B", 30, 1);
            cart.AddCart(3, "C", 20, 1);
            var totalprice=cart.CheckOut();
            Assert.AreEqual(100, totalprice);
        }

       
    }
}
