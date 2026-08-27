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


        public void Edit(Product product)
        {
            var originalProduct = TryGetById(product.Id);

            if(product != null)
            {
                originalProduct.Name = product.Name;
                originalProduct.Cost = product.Cost;
                originalProduct.Description = product.Description;
            }
        }

        public void Delete(int id)
        {
            var product = TryGetById(id);

            if(product is not null)
            {
                _products.Remove(product);
            }
            
        }

        public void Add(Product product)
        {
            product.Id = ++_instanceCounter;
            _products.Add(product);
        }

        public List<Product>? Search(string? query)
        {
            if (query is null)
            {
                return [];
            }
            return _products.Where(x => x.Name.Contains(query, StringComparison.OrdinalIgnoreCase))?.ToList() ?? [];
        }
    }
}
