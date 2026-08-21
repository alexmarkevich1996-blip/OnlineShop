using OnlineShop.Models;

namespace OnlineShop.Interfaces
{
    public interface IProductsRepository
    {

        List<Product> GetAll();
        Product? TryGetById(int id);
        void Add(string name, decimal cost, string description);

    }
}
