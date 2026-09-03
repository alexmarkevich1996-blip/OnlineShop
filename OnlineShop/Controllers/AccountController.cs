using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authorization(Authorization authorization)
        {
            if (authorization.Login == authorization.Password)
                ModelState.AddModelError("", "Login and password should not match");

            if (!ModelState.IsValid)
                return View(authorization);

            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Registration registration)
        {
            if(registration.Login == registration.Password)
            {
                ModelState.AddModelError("", "Login and password should not match");
            }

            if (!ModelState.IsValid)
            {
                return View(registration);
            }

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
