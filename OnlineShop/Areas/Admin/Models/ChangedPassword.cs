using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Areas.Admin.Models
{
    public class ChangedPassword
    {
        [Display(Name = "Login", Prompt = "Your login")]
        [Required(ErrorMessage = "Login not specified")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        [DataType(DataType.EmailAddress)]
        [AllowNull]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password should be from {2} to {1} symbols")]
        [AllowNull]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [Required(ErrorMessage = "Password Confirmation not specified")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [AllowNull]
        public string ConfirmPassword { get; set; }
    }
}
