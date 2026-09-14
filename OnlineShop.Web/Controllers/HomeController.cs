using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OnlineShop.Core.Interfaces;

namespace OnlineShop.Controllers
{
    public class HomeController(IProductsRepository productsRepository) : Controller
    {
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            var products = productsRepository.Search(query);

            return View(products);
            
        }

    }

    
}
