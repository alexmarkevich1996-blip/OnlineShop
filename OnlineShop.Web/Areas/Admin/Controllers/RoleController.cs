using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;
using OnlineShop.Data.MSSqlServer;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController(IRolesRepository rolesRepository) : Controller
    {
        public IActionResult Index()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            if(rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "This role is already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(role);
            }

            rolesRepository.Add(role);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid roleId)
        {
            rolesRepository.Delete(roleId);

            return RedirectToAction(nameof(Index));
        }

    }
}
