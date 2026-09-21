using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;
using OnlineShop.Data.MSSqlServer;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository) : Controller
    {
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);

            var model = new PlaceOrder
            {
                Items = cart?.Items ?? []
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Buy(PlaceOrder model)
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);

            if (cart is null || cart.Items.Count == 0)
            {
                model.Items = cart?.Items ?? [];
                return View(nameof(Index), model);
            }

            if (!ModelState.IsValid)
            {
                model.Items = cart.Items;
                return View(nameof(Index), model);
            }

            var order = new Order
            {
                UserId = Constants.UserId,
                Items = cart.Items,
                DeliveryUser = model.DeliveryUser,
                Status = OrderStatus.Created
            };

            ordersRepository.Add(order);
            cartsRepository.Clear(Constants.UserId);

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
