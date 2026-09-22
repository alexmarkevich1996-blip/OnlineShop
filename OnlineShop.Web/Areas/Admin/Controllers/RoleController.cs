using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin.ViewModels;
using OnlineShop.Data.MSSqlServer;
using OnlineShop.Validators;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController(RoleManager<IdentityRole> roleManager, IValidator<RoleViewModel> roleViewModelValidator) : Controller
    {
        public IActionResult Index()
        {
            var roles = roleManager.Roles
                .Select(role => new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name
                })
                .ToList();

            return View(roles);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel model)
        {
            var validationResult = await roleViewModelValidator.ValidateAsync(model);
            ModelState.AddValidationErrors(validationResult);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await roleManager.CreateAsync(new IdentityRole(model.Name));

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role != null)
            {
                await roleManager.DeleteAsync(role);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
