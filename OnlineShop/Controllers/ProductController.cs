using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int id)
        {
            var products = new List<Product>()
            {
                new Product { Id = 1, Name = "T-Shirt", Cost = 12.3, Description = "Luxury shirt from Dolce&Gabana" },
                new Product { Id = 2, Name = "Jacket", Cost = 24.0, Description = "Mind-blowing jacket from H&M"},
                new Product { Id = 3, Name = "Sneackers shoes", Cost = 60.8, Description = "Elegant shoes from ECCO"}
            };

            var fetchedProduct = products.Where(p => p.Id == id);
            return Content(string.Join(" ", fetchedProduct));
        }
    }
}
