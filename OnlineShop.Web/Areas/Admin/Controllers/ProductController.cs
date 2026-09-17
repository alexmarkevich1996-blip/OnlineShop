using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.ViewModels;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;
using OnlineShop.Data.MSSqlServer;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController(IProductsRepository productsRepository) : Controller
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

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };

            productsRepository.Add(productDb);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid id)
        {
            var productForEditting = productsRepository.TryGetById(id);

            return View(productForEditting);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
                return View(product);
            
            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };

            productsRepository.Edit(productDb);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            productsRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
