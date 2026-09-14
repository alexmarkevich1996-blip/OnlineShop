using OnlineShop.Core.Models;

namespace OnlineShop.Core.Interfaces
{
    public interface IComparisonsRepository
    {
        Comparison? TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void Remove(int productId, string userId);
        void Clear(string userId);
    }
}
