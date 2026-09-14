using OnlineShop.Core.Models;

namespace OnlineShop.Core.Interfaces
{
    public interface ICartsRepository
    {
        Cart? TryGetByUserId(string userId);

        void Add(Product product, string userId);

        void Subtract(Guid productId, string userId);
        void Clear(string userId);
    }
}
