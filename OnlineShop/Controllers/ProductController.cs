using Microsoft.AspNetCore.Mvc;
using OnlineShop.Repositories;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        public string Index(int id)
        {
            var product = ProductsRepository.TryGetById(id);

            if (product == null)
                return $"There is no product with id = {id} in the system";
            else
                return $"{product}{Environment.NewLine}{product.Description}";
        }
    }
}
