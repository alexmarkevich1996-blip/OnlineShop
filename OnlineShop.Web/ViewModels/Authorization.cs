using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels
{
    public class Authorization
    {
        [Display(Name = "Login", Prompt = "Your login")]
        [DataType(DataType.EmailAddress)]
        public required string Login { get; set; }

        [Display(Name = "Password", Prompt = "Your password")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool IsRememberMe { get; set; }
    }
}
