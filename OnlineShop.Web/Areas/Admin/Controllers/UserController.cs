using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Areas.Admin.ViewModels;
using OnlineShop.Core.DTO;
using OnlineShop.Core.Models;
using OnlineShop.Data.MSSqlServer;
using OnlineShop.Validators;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IValidator<AddUser> addUserValidator,
        IValidator<UserViewModel> userViewModelValidator,
        IValidator<ChangedPassword> changedPasswordValidator,
        IValidator<ChangeRole> changeRoleValidator) : Controller
    {
        public IActionResult Index()
        {
            var users = userManager.Users
                .Select(user => new UserViewModel
                {
                    Id = user.Id,
                    Login = user.Login,
                    Name = user.Name,
                    Surname = user.Surname,
                    Age = user.Age,
                    Phone = user.Phone,
                    CreationDateTime = user.CreationDateTime
                })
                .ToList();

            return View(users);
        }

        public async Task<IActionResult> Detail(string login)
        {
            var user = await userManager.FindByNameAsync(login);

            if (user == null)
                return View((UserViewModel?)null);

            var roles = await userManager.GetRolesAsync(user);

            var model = new UserViewModel
            {
                Id = user.Id,
                Login = user.Login,
                Name = user.Name,
                Surname = user.Surname,
                Age = user.Age,
                Phone = user.Phone,
                Role = roles.FirstOrDefault(),
                CreationDateTime = user.CreationDateTime
            };

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUser model)
        {
            var validationResult = await addUserValidator.ValidateAsync(model);
            ModelState.AddValidationErrors(validationResult);

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
            var user = await userManager.FindByNameAsync(login);

            if (user == null)
                return View((UserViewModel?)null);

            var model = new UserViewModel
            {
                Id = user.Id,
                Login = user.Login,
                Name = user.Name,
                Surname = user.Surname,
                Age = user.Age,
                Phone = user.Phone,
                CreationDateTime = user.CreationDateTime
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            var validationResult = await userViewModelValidator.ValidateAsync(model);
            ModelState.AddValidationErrors(validationResult);

            if (!ModelState.IsValid)
                return View(model);

            var existingUser = await userManager.FindByNameAsync(model.Login);

            if (existingUser != null)
            {
                existingUser.Name = model.Name;
                existingUser.Surname = model.Surname;
                existingUser.Age = model.Age;
                existingUser.Phone = model.Phone;

                await userManager.UpdateAsync(existingUser);
            }

            return RedirectToAction(nameof(Detail), new { login = model.Login });
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
            var validationResult = await changedPasswordValidator.ValidateAsync(changedPassword);
            ModelState.AddValidationErrors(validationResult);

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
            var validationResult = await changeRoleValidator.ValidateAsync(changeRole);
            ModelState.AddValidationErrors(validationResult);

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
