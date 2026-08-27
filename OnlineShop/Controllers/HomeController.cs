using Microsoft.AspNetCore.Mvc;
using OnlineShop.Interfaces;
using OnlineShop.Models;
using System.Diagnostics;

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
