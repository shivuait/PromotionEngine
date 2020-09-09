using System.Collections.Generic;
using DomainModels.Entities;
using Repository.Abstraction;

namespace Repository.Implementation
{
    public class CartRepository : ICartRepository
    {
        readonly Dictionary<int, CartItem> dicCart;

        public CartRepository()
        {
            dicCart = new Dictionary<int, CartItem>() { };
        }

        public void AddCart(int productId, string name, int unitPrice, int quantity)
        {
           if(!dicCart.ContainsKey(productId))
            {
                var cartitem = new CartItem
                {
                    ProductId = productId,
                    Name = name,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                };
                dicCart.Add(productId,cartitem);
            }
           else
            {
                var cart = dicCart[productId];
                cart.Quantity = cart.Quantity + quantity;
            }
        }

       public int calculateCart(out decimal price)
        {
            var count = 0;
            price = 0;
            foreach (var item in dicCart)
            {
                count += item.Value.Quantity;
                price += item.Value.Total = CalculateDiscounts(item.Value);
            }
            return count;
        }

        private static decimal CalculateDiscounts(CartItem cart)
        {
            decimal price = 0;
            switch (cart.Name)
            {
                case "A":
                    cart.Total = ((cart.Quantity % 3) * cart.UnitPrice) + ((cart.Quantity / 3) * 130);
                    break;
                case "B":
                    cart.Total = ((cart.Quantity % 2) * cart.UnitPrice) + ((cart.Quantity / 2) * 45);
                    break;
                default:
                    cart.Total = cart.Quantity * cart.UnitPrice;
                    break;
            }
            price = cart.Total;
            return price;
        }

        public decimal CheckOut()
        {
            decimal total;
            calculateCart(out total);
            return total;
        }

        public void DeleteCart(int productId)
        {
            if (dicCart.ContainsKey(productId))
            {
                dicCart.Remove(productId);
            }
        }

    }
}
