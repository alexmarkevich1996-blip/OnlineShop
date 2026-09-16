using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.MSSqlServer.Repositories
{
    public class ProductsDbRepository(DatabaseContext dbContext) : IProductsRepository
    {
        public List<Product> GetAll() => 
            dbContext.Products.ToList();
        public Product? TryGetById(Guid id) => 
            dbContext.Products.FirstOrDefault(p => p.Id == id);

        public void Edit(Product product)
        {
            var existingProduct = TryGetById(product.Id);

            if(existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Cost = product.Cost;
                existingProduct.Description = product.Description;
            }

            dbContext.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var product = TryGetById(id);

            if(product is not null)
            {
                dbContext.Products.Remove(product);
            }
            dbContext.SaveChanges();
            
        }
        public void Add(Product product)
        {
            dbContext.Products.Add(product);
            
            dbContext.SaveChanges();
        }
        public List<Product>? Search(string? query)
        {
            if (query is null)
            {
                return [];
            }
            return dbContext.Products.Where(x => x.Name.Contains(query, StringComparison.OrdinalIgnoreCase))?.ToList() ?? [];
        }
    }
}
