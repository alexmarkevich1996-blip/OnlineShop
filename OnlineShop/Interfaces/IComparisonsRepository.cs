using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Interfaces
{
    public interface IComparisonsRepository
    {
        Comparison? TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void Remove(int productId, string userId);
        void Clear(string userId);
    }
}
