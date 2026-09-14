using OnlineShop.Core.Models;

namespace OnlineShop.Core.Interfaces
{
    public interface IOrdersRepository
    {
        List<Order> GetAll();
        Order? TryGetById(Guid id);
        void UpdateStatus(Guid id, OrderStatus status);
        void Add(Order order);

        
    }
}
