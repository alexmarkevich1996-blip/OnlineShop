using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OnlineShop.Areas.Admin.ViewModels;
using OnlineShop.Core.Interfaces;

namespace OnlineShop.Controllers
{
    public class HomeController(IProductsRepository productsRepository) : Controller
    {
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModels = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    PhotoPath = product.PhotoPath
                };
                productsViewModels.Add(productViewModels);
            }

            return View(productsViewModels);
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
