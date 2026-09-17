using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Areas.Admin.ViewModels;
using OnlineShop.Core.DTO;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;
using OnlineShop.Data.MSSqlServer;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController(IUsersRepository usersRepository, IRolesRepository rolesRepository) : Controller
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
        public IActionResult Add(User user)
        {
            if (usersRepository.TryGetByLogin(user.Login) != null)
                ModelState.AddModelError("", "That user already exists!");

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
        public IActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            usersRepository.Edit(user);

            return RedirectToAction(nameof(Detail), new { login = user.Login });
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

            return RedirectToAction(nameof(Detail), new { login = changedPassword.Login });
        }

        public IActionResult Delete(string login)
        {
            usersRepository.Delete(login);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ChangeRole(string login)
        {
            var existingUser = usersRepository.TryGetByLogin(login);

            var changeRole = new ChangeRole()
            {
                Login = existingUser?.Login,
                Role = existingUser?.Role?.ToString(),
                Roles = rolesRepository
                    .GetAll()
                    .Select(role => new SelectListItem()
                        {
                            Value = role.Name.ToString(),
                            Text = role.Name
                        })
                    .ToList()

            };

            return View(changeRole);
        }

        [HttpPost]
        public IActionResult ChangeRole(ChangeRole changeRole)
        {
            if (!ModelState.IsValid)
                return View(changeRole);

            usersRepository.ChangeRole(changeRole.Login, rolesRepository.TryGetByName(changeRole.Role));

            return RedirectToAction(nameof(Detail), new { login = changeRole.Login });
        }

    }
}
