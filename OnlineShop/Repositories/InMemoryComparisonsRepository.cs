using OnlineShop.Interfaces;
using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public class InMemoryComparisonsRepository : IComparisonsRepository
    {
        private readonly List<Comparison> _comparisons = [];
        public Comparison? TryGetByUserId(string userId)
        {
            return _comparisons.FirstOrDefault(c => c.UserId == userId);
        }
        public void Add(Product product, string userId)
        {
            var comparison = TryGetByUserId(userId);

            if(comparison is null)
            {
                comparison = new Comparison()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = [product]
                };
                _comparisons.Add(comparison);
            }
            else
            {
                var existingComparisonItems = comparison.Items.FirstOrDefault(item => item.Id == product.Id);

                if (existingComparisonItems is null)
                {
                    comparison.Items.Add(product);
                }
            }
        }
        public void Remove(int productId, string userId)
        {
            var comparison = TryGetByUserId(userId);

            if(comparison is not null)
            {
                comparison.Items.RemoveAll(item => item.Id == productId);
            }
        }

        public void Clear(string userId)
        {
            var comparison = TryGetByUserId(userId);

            if(comparison is not null)
            {
                _comparisons.Remove(comparison);
            }
        }

        

        
    }
}
