using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Repositories;
using System.Diagnostics;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetAll();

            return View(products);
        }

    }

    
}
