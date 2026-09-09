using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Repositories;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersRepository usersManager;

        public AccountController(IUsersRepository usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Authorize()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Authorize(Authorization authorization)
        {

            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Authorize));

            var userAccount = usersManager.TryGetByLogin(authorization.Login);

            if (userAccount == null)
            {
                ModelState.AddModelError("", "That users doesn't exist");
                return RedirectToAction(nameof(Authorize));
            }

            if (userAccount.Password != authorization.Password)
            {
                ModelState.AddModelError("", "Incorrect password");
                return RedirectToAction(nameof(Authorize));
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");


        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Registration registration)
        {
            if(registration.Login == registration.Password)
            {
                ModelState.AddModelError("", "Login and password should not match");
            }

            if (ModelState.IsValid)
            {
                usersManager.Add(new UserAccount
                {
                    Name = registration.Name,
                    Surname = registration.Surname,
                    Age = registration.Age,
                    Phone = registration.Phone,
                    Password = registration.Password,
                    Login = registration.Login
                });

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return RedirectToAction(nameof(Register));
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
