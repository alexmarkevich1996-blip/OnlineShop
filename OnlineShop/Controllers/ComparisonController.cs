using Microsoft.AspNetCore.Mvc;
using OnlineShop.Interfaces;

namespace OnlineShop.Controllers
{
    public class ComparisonController(IComparisonsRepository comparisonsRepository, IProductsRepository productsRepository) : Controller
    {
        public IActionResult Index()
        {
            var comparison = comparisonsRepository.TryGetByUserId(Constants.UserId);
            return View(comparison);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);

            if (product is null)
            {
                return RedirectToAction("Index", "Home");
            }

            comparisonsRepository.Add(product, Constants.UserId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int productId)
        {
            comparisonsRepository.Remove(productId, Constants.UserId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            comparisonsRepository.Clear(Constants.UserId);

            return RedirectToAction(nameof(Index));
        }
    }
}
