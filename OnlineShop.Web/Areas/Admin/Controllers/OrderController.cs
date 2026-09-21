using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.ViewModels;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;
using OnlineShop.Data.MSSqlServer;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrderController(IOrdersRepository ordersRepository) : Controller
    {
        public IActionResult Index()
        {
            var orders = ordersRepository.GetAll()
                .Select(ToViewModel)
                .ToList();

            return View(orders);
        }

        public IActionResult Detail(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);

            return View(order == null ? null : ToViewModel(order));
        }

        private static OrderViewModel ToViewModel(Order order) => new()
        {
            Id = order.Id,
            UserId = order.UserId,
            TotalCost = order.TotalCost,
            ItemsQuantity = order.ItemsQuantity,
            Status = order.Status,
            CreationDateTime = order.CreationDateTime,
            DeliveryUser = order.DeliveryUser,
            Items = order.Items
        };

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);

            return RedirectToAction("Index");
        }

    }
}
