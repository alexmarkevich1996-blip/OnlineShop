using OnlineShop.Models;

namespace OnlineShop.Interfaces
{
    public interface IProductsRepository
    {

        List<Product> GetAll();
        Product? TryGetById(int id);
        List<Product>? Search(string? query);
        void Add(Product product);
        void Edit(Product product);
        void Delete(int id);

    }
}
