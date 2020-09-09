namespace Repository.Abstraction
{
    public interface ICartRepository
    {
        void AddCart(int productId, string name, int unitPrice, int quantity);
        void DeleteCart(int productId);
        int calculateCart(out decimal price);
        decimal CheckOut();
    }
}
