namespace Repository.Abstraction
{
    public interface ICartRepository
    {
        /// <summary>
        /// Add the Selected item to Cart with product Id, Name, UnitPrice and quantity
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="unitPrice"></param>
        /// <param name="quantity"></param>void AddCart(int productId, string name, int unitPrice, int quantity);
        void AddCart(int productId, string name, int unitPrice, int quantity);
        /// <summary>
        /// Delete items from the cart
        /// </summary>
        /// <param name="productId"></param>
        void DeleteCart(int productId);
        /// <summary>
        /// Calculate the price of the items in the cart
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        int CalculateCart(out decimal price);
        /// <summary>
        /// Check out the cart
        /// </summary>
        /// <returns></returns>
        decimal CheckOut();
    }
}
