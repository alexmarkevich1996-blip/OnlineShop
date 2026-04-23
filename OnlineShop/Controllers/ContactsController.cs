using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
