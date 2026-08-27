using Microsoft.AspNetCore.Mvc;
using OnlineShop.Interfaces;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class AdminController(IProductsRepository productsRepository) : Controller
    {

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {
            var products = productsRepository.GetAll();

            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productsRepository.Add(product);
            return RedirectToAction(nameof(Products));
        }

        public IActionResult EditProduct(int id)
        {
            var productForEditting = productsRepository.TryGetById(id);

            return View(productForEditting);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            productsRepository.Edit(product);

            return RedirectToAction(nameof(Products));
        }

        public IActionResult DeleteProduct(int id)
        {
            productsRepository.Delete(id);

            return RedirectToAction(nameof(Products));
        }
    }
}
