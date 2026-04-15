using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Repositories;
using System.Diagnostics;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            var products = ProductsRepository.GetAll();
            var result = string.Empty;

            foreach (var product in products)
            {
                result += product + Environment.NewLine + Environment.NewLine;
            }

            return result;
        }

    }

    
}
