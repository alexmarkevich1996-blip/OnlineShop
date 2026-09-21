using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces;
using OnlineShop.Data.MSSqlServer;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class CartController(ICartsRepository cartsRepository, IProductsRepository productsRepository) : Controller
    {

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);

            var model = new CartViewModel
            {
                Items = cart?.Items ?? []
            };

            return View(model);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);

            if (product != null)
            {
                cartsRepository.Add(product, Constants.UserId);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Subtract(Guid productId)
        {
            cartsRepository.Subtract(productId, Constants.UserId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            cartsRepository.Clear(Constants.UserId);

            return RedirectToAction("Index");
        }
    }
}
