using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces;

namespace OnlineShop.Controllers
{
    public class CartController(ICartsRepository cartsRepository, IProductsRepository productsRepository) : Controller
    {

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
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
