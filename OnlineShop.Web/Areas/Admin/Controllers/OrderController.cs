using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController(IOrdersRepository ordersRepository) : Controller
    {
        public IActionResult Index()
        {
            var orders = ordersRepository.GetAll();

            return View(orders);
        }

        public IActionResult Detail(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);

            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);

            return RedirectToAction("Index");
        }

    }
}
