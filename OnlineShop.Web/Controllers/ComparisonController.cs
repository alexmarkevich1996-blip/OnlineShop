using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces;
using OnlineShop.Data.MSSqlServer;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class ComparisonController(IComparisonsRepository comparisonsRepository, IProductsRepository productsRepository) : Controller
    {
        public IActionResult Index()
        {
            var comparison = comparisonsRepository.TryGetByUserId(Constants.UserId);

            var model = new ComparisonViewModel
            {
                Items = comparison?.Items ?? []
            };

            return View(model);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);

            if (product is null)
            {
                return RedirectToAction("Index", "Home");
            }

            comparisonsRepository.Add(product, Constants.UserId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
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
