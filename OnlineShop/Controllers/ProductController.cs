using Microsoft.AspNetCore.Mvc;
using OnlineShop.Interfaces;

namespace OnlineShop.Controllers
{
    public class ProductController(IProductsRepository productsRepository) : Controller
    {
        public IActionResult Index(int id)
        {
            var product = productsRepository.TryGetById(id);

            return View(product);
        }

        public IActionResult Add(string name, decimal cost, string description)
        {
            productsRepository.Add(name, cost, description);

            return RedirectToAction("Index","Home");
        }
    }
}
