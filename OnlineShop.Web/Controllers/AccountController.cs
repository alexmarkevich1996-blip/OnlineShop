using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;
using OnlineShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Data.MSSqlServer;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUsersRepository usersRepository, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _usersRepository = usersRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Authorization auth)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(auth.Login, auth.Password, auth.IsRememberMe, false);

                if(result.Succeeded)
                    return RedirectToAction(nameof(HomeController.Index), "Home");

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(auth);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Registration registration)
        {
            if(registration.Login == registration.Password)
            {
                ModelState.AddModelError("", "Login and password should not match");
            }
       
            if(!ModelState.IsValid)
               return View(registration);

            var user = new User
            {
                UserName = registration.Login,
                Email = registration.Login,
                Login = registration.Login,
                Name = registration.Name,
                Surname = registration.Surname,
                Age = registration.Age,
                Phone = registration.Phone,
                CreationDateTime = DateTime.Now
            };
            
            var result = await _userManager.CreateAsync(user, registration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(error.Code, error.Description);
                
                return View(registration);
            }
            
            await _userManager.AddToRoleAsync(user, Constants.UserRoleName );
            await _signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
