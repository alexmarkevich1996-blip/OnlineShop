using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Core.DTO
{
    public class ChangedPassword
    {
        [Display(Name = "Login", Prompt = "Your login")]
        [DataType(DataType.EmailAddress)]
        [AllowNull]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [AllowNull]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [DataType(DataType.Password)]
        [AllowNull]
        public string ConfirmPassword { get; set; }
    }
}
