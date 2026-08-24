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

            return View(cart);
        }

        [HttpPost]
        public IActionResult Buy()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);

            if(cart is null)
            {
                return RedirectToAction("Index", "Home");
            }

            var order = new Order()
            {
                UserId = Constants.UserId,
                Items = cart.Items
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
