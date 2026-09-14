using OnlineShop.Core.Models;

namespace OnlineShop.Core.Interfaces
{
    public interface IOrdersRepository
    {
        List<Order> GetAll();
        Order? TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus status);
        void Add(Order order);

        
    }
}
