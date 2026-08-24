using Microsoft.AspNetCore.Mvc;
using OnlineShop.Interfaces;

namespace OnlineShop.Controllers
{
    public class FavoriteController(IFavoritesRepository favoritesRepository, IProductsRepository productsRepository) : Controller
    {
        public IActionResult Index()
        {
            var favorite = favoritesRepository.TryGetByUserId(Constants.UserId);
            return View(favorite);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);

            if(product is null)
            {
                return RedirectToAction("Index", "Home");
            }

            favoritesRepository.Add(product, Constants.UserId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int productId)
        {
            favoritesRepository.Remove(productId, Constants.UserId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            favoritesRepository.Clear(Constants.UserId);

            return RedirectToAction(nameof(Index));
        }
    }
}
