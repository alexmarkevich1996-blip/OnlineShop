using OnlineShop.Models;

namespace OnlineShop.Interfaces
{
    public interface IOrdersRepository
    {
        List<Order> GetAll();
        Order? TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus status);
        void Add(Order order);

        
    }
}
