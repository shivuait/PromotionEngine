using System.Collections.Generic;
using DomainModels.Entities;
using Repository.Abstraction;

namespace Repository.Implementation
{
    public class CartRepository : ICartRepository
    {
        readonly Dictionary<int, CartItem> _dicCart;

        public CartRepository()
        {
            _dicCart = new Dictionary<int, CartItem>() { };
        }
        /// <summary>
        /// Add the Selected item to Cart with product Id, Name, UnitPrice and quantity
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="unitPrice"></param>
        /// <param name="quantity"></param>
        public void AddCart(int productId, string name, int unitPrice, int quantity)
        {
            if (!_dicCart.ContainsKey(productId))
            {
                var cartitem = new CartItem
                {
                    ProductId = productId,
                    Name = name,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                };
                _dicCart.Add(productId, cartitem);
            }
            else
            {
                var cart = _dicCart[productId];
                cart.Quantity = cart.Quantity + quantity;
            }
        }
        
        /// <summary>
        /// Calculate the price of the items in the cart
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public int CalculateCart(out decimal price)
        {
            var count = 0;
            price = 0;
            foreach (var item in _dicCart)
            {
                count += item.Value.Quantity;
                price += item.Value.Total = CalculateDiscounts(item.Value);
            }
            return count;
        }

        /// <summary>
        /// Applies Promotional discount
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Check out the cart
        /// </summary>
        /// <returns></returns>
        public decimal CheckOut()
        {
            decimal total;
            CalculateCart(out total);
            return total;
        }

        /// <summary>
        /// Delete items from the cart
        /// </summary>
        /// <param name="productId"></param>
        public void DeleteCart(int productId)
        {
            if (_dicCart.ContainsKey(productId))
            {
                _dicCart.Remove(productId);
            }
        }

    }
}
