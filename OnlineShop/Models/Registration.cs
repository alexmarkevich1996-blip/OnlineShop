using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Registration
    {
        [Required(ErrorMessage ="Name not specified")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "The length should be from {2} to {1} symbols")]
        public string Name { get; set; }

        [Display(Name = "Age", Prompt = "Your age")]
        [Required(ErrorMessage = "Age not specified")]
        [Range(16, 100, ErrorMessage = "Age should be from {1} to {2} years")]
        public int Age { get; set; }

        [Display(Name = "Login", Prompt = "Your login")]
        [Required(ErrorMessage = "Login not specified")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Phone number not specified")]
        [RegularExpression(@"\d{4}-\d{3}-\d{4}")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [Required(ErrorMessage = "Password Confirmation not specified")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
