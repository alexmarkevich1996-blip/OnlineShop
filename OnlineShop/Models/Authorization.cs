using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Authorization
    {
        [Display(Name = "Login", Prompt = "Your login")]
        [Required(ErrorMessage = "Login not specified")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "The length should be from {2} to {1} symbols")]
        public required string Login { get; set; }

        [Display(Name = "Password", Prompt = "Your password")]
        [Required(ErrorMessage = "Login not specified")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "The length should be from {2} to {1} symbols")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Display(Name = "Remember me")]
        [Required]
        public bool IsRememberMe { get; set; }
    }
}
