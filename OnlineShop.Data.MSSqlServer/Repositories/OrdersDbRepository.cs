using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.MSSqlServer.Repositories
{
    public class OrdersDbRepository(DatabaseContext dbContext) : IOrdersRepository
    {
        public void Add(Order order)
        {
            order.Id = Guid.NewGuid();
            order.DeliveryUser.Id = Guid.NewGuid();
            order.CreationDateTime = DateTime.Now;

            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }

        public List<Order> GetAll() => 
            dbContext.Orders
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .Include(o => o.DeliveryUser)   
                .ToList();

        public Order? TryGetById(Guid id) => 
            dbContext.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Include(o => o.DeliveryUser)
                .FirstOrDefault(order => order.Id == id);

        public void UpdateStatus(Guid id, OrderStatus newStatus)
        {
            var existingOrder = TryGetById(id);

            if(existingOrder != null)
            {
                existingOrder.Status = newStatus;
            }
            
            dbContext.SaveChanges();
        }
    }
}
