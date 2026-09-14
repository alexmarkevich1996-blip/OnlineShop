using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces;

namespace OnlineShop.Controllers
{
    public class ProductController(IProductsRepository productsRepository) : Controller
    {
        public IActionResult Index(Guid id)
        {
            var product = productsRepository.TryGetById(id);

            return View(product);
        }

    }
}
