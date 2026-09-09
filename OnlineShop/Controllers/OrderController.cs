using Microsoft.AspNetCore.Mvc;
using OnlineShop.Interfaces;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository) : Controller
    {
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);

            var order = new Order
            {
                Items = cart?.Items ?? []
            };

            return View(order);
        }

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);

            if(cart is null)
            {
                return View(nameof(Index), order); 
            }
            order.UserId = Constants.UserId;
            order.Items = cart.Items;

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
