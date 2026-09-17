using Microsoft.AspNetCore.Identity;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.MSSqlServer;

public class IdentityInitializer
{
    public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        var adminEmail = "admin@gmail.com";
        var password = "Qwerty123!";

        if (roleManager.FindByNameAsync(Constants.AdminRoleName).Result == null)
        {
            roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName)).Wait();
        }

        if (roleManager.FindByNameAsync(Constants.UserRoleName).Result == null)
        {
            roleManager.CreateAsync(new IdentityRole(Constants.UserRoleName)).Wait();
        }

        if (userManager.FindByNameAsync(adminEmail).Result == null)
        {
            var admin = new User
            {
                Email = adminEmail,
                UserName = adminEmail,
                Login = adminEmail,
                Name = "Admin",
                Surname = "Admin",
                Phone = "+00000000000",
                CreationDateTime = DateTime.Now
            };
            var result = userManager.CreateAsync(admin, password).Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(admin, Constants.AdminRoleName).Wait();
            }
        }
    }  
}