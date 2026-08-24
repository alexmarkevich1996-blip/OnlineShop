using OnlineShop.Models;

namespace OnlineShop.Interfaces
{
    public interface IFavoritesRepository
    {
        Favorite? TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void Remove(int productId, string userId);
        void Clear(string userId);
    }
}
