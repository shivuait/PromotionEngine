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
             
    }
}
