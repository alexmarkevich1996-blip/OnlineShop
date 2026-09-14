using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.InMemory
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        private readonly List<Product> _products =
        [
            new Product(Guid.NewGuid(), "T-Shirt Dolce", 1000, "Luxury shirt from Dolce&Gabana"),
            new Product(Guid.NewGuid(), "Jacket H&M", 2000, "Mind-blowing jacket from H&M"),
            new Product(Guid.NewGuid(), "Sneackers shoes ECCO", 3500, "Elegant shoes from ECCO"),
            new Product(Guid.NewGuid(), "Trousers Benetor", 5000, "Amazing trousers from Beneton"),
            new Product(Guid.NewGuid(), "T-Shirt Addidas", 8500, "Luxury shirt from Addidas"),
            new Product(Guid.NewGuid(), "Jacket Nike", 2000, "Mind-blowing jacket from Nike"),
            new Product(Guid.NewGuid(), "Sneackers shoes Nike", 3500, "Elegant shoes from Nike"),
            new Product(Guid.NewGuid(), "Trousers Addidas", 5000, "Amazing trousers from Addidas")
        ];
        
        public List<Product> GetAll() => _products;
        public Product? TryGetById(Guid id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public void Edit(Product product)
        {
            var existingProduct = TryGetById(product.Id);

            if(existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Cost = product.Cost;
                existingProduct.Description = product.Description;
            }
        }
        public void Delete(Guid id)
        {
            var product = TryGetById(id);

            if(product is not null)
            {
                _products.Remove(product);
            }
            
        }
        public void Add(Product product)
        {
            product.Id = Guid.NewGuid();
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
