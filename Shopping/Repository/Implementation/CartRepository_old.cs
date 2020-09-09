using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Entities;
using System.Data.Entity;
using Repository.Abstraction;

namespace BAL.Implementation
{
    public class CartRepository : ICartRepository
    {
        Dictionary<int, CartItem> dicCart;

        public CartRepository()
        {
            dicCart = new Dictionary<int, CartItem>() { };
        }
        public void AddCart(int ProductId, string Name, int UnitPrice, int Quantity)
        {
           if(!dicCart.ContainsKey(ProductId))
            {
                var cartitem = new CartItem
                {
                    ProductId = ProductId,
                    Name = Name,
                    UnitPrice = UnitPrice,
                    Quantity = Quantity

                };
                dicCart.Add(ProductId,cartitem);
            }
           else
            {
                var cart = dicCart[ProductId];
                cart.Quantity = cart.Quantity + Quantity;

                if (cart.Name == "A")
                {
                    //var v0 = cart.Quantity%3;
                    //var v1 = (v0)*130;
                    //var v01 = cart.Quantity/3;
                    //var v2 = ((v01) * UnitPrice);
                    //cart.UnitPrice = v1 + v2;

                    cart.UnitPrice = ((cart.Quantity % 3) * 130) + ((cart.Quantity / 3) * UnitPrice);
                }
                if (cart.Name == "B")
                {
                    cart.UnitPrice = ((cart.Quantity % 2) * 45) + ((cart.Quantity / 2) * UnitPrice);
                }
                else
                {
                    cart.UnitPrice = cart.Quantity * UnitPrice;
                }
            }
        }
       public int calculateCart(out decimal price)
        {
            int count = 0;
            price = 0;
            foreach (KeyValuePair<int,CartItem> item in dicCart)
            {
                count += item.Value.Quantity;
                price += item.Value.Total =  item.Value.UnitPrice;
            }

            return count;
        }

        public decimal CheckOut()
        {
           decimal total = 0;
            calculateCart(out total);
            return total;
        }

        public void DeleteCart(int ProductId)
        {
            if (dicCart.ContainsKey(ProductId))
            {
                dicCart.Remove(ProductId);
            }
        }

    }
}
