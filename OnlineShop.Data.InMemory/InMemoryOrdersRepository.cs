using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.InMemory
{
    public class InMemoryOrdersRepository : IOrdersRepository
    {
        private readonly List<Order> _orders = [];
        public void Add(Order order)
        {
            order.Id = Guid.NewGuid();
            order.DeliveryUser.Id = Guid.NewGuid();
            order.CreationDateTime = DateTime.Now;

            _orders.Add(order);
        }

        public List<Order> GetAll() => _orders;

        public Order? TryGetById(Guid id) => _orders.FirstOrDefault(order => order.Id == id);

        public void UpdateStatus(Guid id, OrderStatus newStatus)
        {
            var existingOrder = TryGetById(id);

            if(existingOrder != null)
            {
                existingOrder.Status = newStatus;
            }
        }
    }
}
