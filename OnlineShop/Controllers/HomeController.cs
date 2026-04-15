using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using System.Diagnostics;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = new List<Product>()
            {
                new Product { Id = 1, Name = "T-Shirt", Cost = 12.3, Description = "Luxury shirt from Dolce&Gabana" },
                new Product { Id = 2, Name = "Jacket", Cost = 24.0, Description = "Mind-blowing jacket from H&M"},
                new Product { Id = 3, Name = "Sneackers shoes", Cost = 60.8, Description = "Elegant shoes from ECCO"}
            };

            string result = "";
            foreach (var product in products)
            {
                result += $"{product.Id}\n{product.Name}\n{product.Cost}\n\n";
            }
            return Content(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}\n{Description}";
        }
    }
}
