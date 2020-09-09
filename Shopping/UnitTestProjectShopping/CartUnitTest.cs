using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void ScenarioB()
        {
            cart.AddCart(1, "A", 50, 5);
            cart.AddCart(2, "B", 30, 5);
            cart.AddCart(3, "C", 20, 1);
            var totalprice = cart.CheckOut();
            Assert.AreEqual(370, totalprice);
        }

        [TestMethod]
        public void ScenarioC()
        {
            cart.AddCart(1, "A", 50, 3);
            cart.AddCart(2, "B", 30, 5);
            cart.AddCart(3, "C", 20, 1);
            cart.AddCart(4, "D", 15, 1);
            var totalprice = cart.CheckOut();
            Assert.AreEqual(285, totalprice);
        }
    }
}
