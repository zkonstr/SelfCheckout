using SelfCheckuot.Shop;

namespace SelfCheckuot.Database
{
    public interface IStoreDao
    {
        bool Connect(string url);
        bool Disconnect();
        bool InsertProduct(Product product);
        Product ReadProduct(int id);
        Product[] ReadAllProducts();
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}