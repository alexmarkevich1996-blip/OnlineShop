using OnlineShop.Core.Models;

namespace OnlineShop.Core.Interfaces
{
    public interface IFavoritesRepository
    {
        Favorite? TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void Remove(Guid productId, string userId);
        void Clear(string userId);
    }
}
