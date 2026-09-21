using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces;
using OnlineShop.Data.MSSqlServer;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class FavoriteController(IFavoritesRepository favoritesRepository, IProductsRepository productsRepository) : Controller
    {
        public IActionResult Index()
        {
            var favorite = favoritesRepository.TryGetByUserId(Constants.UserId);

            var model = new FavoriteViewModel
            {
                Items = favorite?.Items ?? []
            };

            return View(model);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);

            if(product is null)
            {
                return RedirectToAction("Index", "Home");
            }

            favoritesRepository.Add(product, Constants.UserId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
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
