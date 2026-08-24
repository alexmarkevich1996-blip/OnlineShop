using OnlineShop.Interfaces;
using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        private int _instanceCounter = 0;
        private readonly List<Product> _products;

        public InMemoryProductsRepository()
        {
            _products =
            [
                new Product(++_instanceCounter, "T-Shirt Dolce", 1000, "Luxury shirt from Dolce&Gabana"),
                new Product(++_instanceCounter, "Jacket H&M", 2000, "Mind-blowing jacket from H&M"),
                new Product(++_instanceCounter, "Sneackers shoes ECCO", 3500, "Elegant shoes from ECCO"),
                new Product(++_instanceCounter, "Trousers Benetor", 5000, "Amazing trousers from Beneton"),
                new Product(++_instanceCounter, "T-Shirt Addidas", 8500, "Luxury shirt from Addidas"),
                new Product(++_instanceCounter, "Jacket Nike", 2000, "Mind-blowing jacket from Nike"),
                new Product(++_instanceCounter, "Sneackers shoes Nike", 3500, "Elegant shoes from Nike"),
                new Product(++_instanceCounter, "Trousers Addidas", 5000, "Amazing trousers from Addidas")
            ];
        }
        public List<Product> GetAll() => _products;

        public Product? TryGetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(string name, decimal cost, string description)
        {
            var newProduct = new Product(++_instanceCounter, name, cost, description);
            _products.Add(newProduct);
        }
    }
}
