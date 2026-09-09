using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Interfaces;
using OnlineShop.Models;
using OnlineShop.Repositories;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController(IUsersRepository usersRepository) : Controller
    {
        public IActionResult Index()
        {
            var users = usersRepository.GetAll();
            return View(users);
        }

        public IActionResult Detail(string login)
        {
            var user = usersRepository.TryGetByLogin(login);
            return View(user);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserAccount user)
        {
            if (!ModelState.IsValid)
                return View(user);

            usersRepository.Add(user);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string login)
        {
            var userAccount = usersRepository.TryGetByLogin(login);

            return View(userAccount);
        }

        [HttpPost]
        public IActionResult Edit(UserAccount user)
        {
            if (!ModelState.IsValid)
                return View(user);

            usersRepository.Edit(user);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ChangePassword(string login)
        {
            var user = usersRepository.TryGetByLogin(login);

            var model = new ChangedPassword
            {
                Login = user.Login
            };

            return View(model);

        }

        [HttpPost]
        public IActionResult ChangePassword(ChangedPassword changedPassword)
        {
            if (changedPassword.Login == changedPassword.Password)
                ModelState.AddModelError("", "Login and password should not match");
            
            if (changedPassword.Password != changedPassword.ConfirmPassword)
                ModelState.AddModelError("", "Passwords do not match");

            if (!ModelState.IsValid)
                return View(changedPassword);

            usersRepository.ChangePassword(changedPassword);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string login)
        {
            usersRepository.Delete(login);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditRights(string login)
        {
            var user = usersRepository.TryGetByLogin(login);

            return View();
        }

    }
}
