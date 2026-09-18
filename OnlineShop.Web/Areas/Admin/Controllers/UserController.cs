using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Areas.Admin.ViewModels;
using OnlineShop.Core.DTO;
using OnlineShop.Core.Models;
using OnlineShop.Data.MSSqlServer;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : Controller
    {
        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> Detail(string login)
        {
            var user = await userManager.FindByNameAsync(login);

            if (user != null)
            {
                var roles = await userManager.GetRolesAsync(user);
                ViewData["CurrentRole"] = roles.FirstOrDefault();
            }

            return View(user);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUser model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                UserName = model.Login,
                Email = model.Login,
                Login = model.Login,
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                Phone = model.Phone,
                CreationDateTime = DateTime.Now
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(model);
            }

            await userManager.AddToRoleAsync(user, Constants.UserRoleName);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string login)
        {
            var userAccount = await userManager.FindByNameAsync(login);

            return View(userAccount);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            var existingUser = await userManager.FindByNameAsync(user.Login);

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.Age = user.Age;
                existingUser.Phone = user.Phone;

                await userManager.UpdateAsync(existingUser);
            }

            return RedirectToAction(nameof(Detail), new { login = user.Login });
        }

        public async Task<IActionResult> ChangePassword(string login)
        {
            var user = await userManager.FindByNameAsync(login);

            var model = new ChangedPassword
            {
                Login = user?.Login
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangedPassword changedPassword)
        {
            if (changedPassword.Login == changedPassword.Password)
                ModelState.AddModelError("", "Login and password should not match");

            if (changedPassword.Password != changedPassword.ConfirmPassword)
                ModelState.AddModelError("", "Passwords do not match");

            if (!ModelState.IsValid)
                return View(changedPassword);

            var user = await userManager.FindByNameAsync(changedPassword.Login);

            if (user != null)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var result = await userManager.ResetPasswordAsync(user, token, changedPassword.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);

                    return View(changedPassword);
                }
            }

            return RedirectToAction(nameof(Detail), new { login = changedPassword.Login });
        }

        public async Task<IActionResult> Delete(string login)
        {
            var user = await userManager.FindByNameAsync(login);

            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeRole(string login)
        {
            var existingUser = await userManager.FindByNameAsync(login);
            var currentRoles = existingUser != null
                ? await userManager.GetRolesAsync(existingUser)
                : [];

            var changeRole = new ChangeRole()
            {
                Login = existingUser?.Login,
                Role = currentRoles.FirstOrDefault(),
                Roles = roleManager.Roles
                    .Select(role => new SelectListItem()
                    {
                        Value = role.Name,
                        Text = role.Name
                    })
                    .ToList()
            };

            return View(changeRole);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(ChangeRole changeRole)
        {
            if (!ModelState.IsValid)
                return View(changeRole);

            var user = await userManager.FindByNameAsync(changeRole.Login);

            if (user != null)
            {
                var currentRoles = await userManager.GetRolesAsync(user);
                await userManager.RemoveFromRolesAsync(user, currentRoles);
                await userManager.AddToRoleAsync(user, changeRole.Role);
            }

            return RedirectToAction(nameof(Detail), new { login = changeRole.Login });
        }
    }
}
