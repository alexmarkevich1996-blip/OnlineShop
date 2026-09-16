using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.MSSqlServer
{
    public class ComparisonsDbRepository(DatabaseContext dbContext) : IComparisonsRepository
    {
        public Comparison? TryGetByUserId(string userId)
        {
            return dbContext.Comparisons
                .Include(c => c.Items)
                .FirstOrDefault(c => c.UserId == userId);
        }
        public void Add(Product product, string userId)
        {
            var comparison = TryGetByUserId(userId);

            if(comparison is null)
            {
                comparison = new Comparison()
                {
                    UserId = userId,
                    Items = [product]
                };
                dbContext.Comparisons.Add(comparison);
            }
            else
            {
                var existingComparisonItems = comparison.Items.FirstOrDefault(item => item.Id == product.Id);

                if (existingComparisonItems is null)
                {
                    comparison.Items.Add(product);
                }
            }
            
            dbContext.SaveChanges();
        }
        public void Remove(Guid productId, string userId)
        {
            var comparison = TryGetByUserId(userId);

            if(comparison is not null)
            {
                comparison.Items.RemoveAll(item => item.Id == productId);
            }
            
            dbContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var comparison = TryGetByUserId(userId);

            if(comparison is not null)
            {
                dbContext.Comparisons.Remove(comparison);
            }
            
            dbContext.SaveChanges();
        }

        

        
    }
}
