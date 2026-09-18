using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin.ViewModels
{
    public class AddUser
    {
        [Display(Name = "Login", Prompt = "Login")]
        [Required(ErrorMessage = "Login not specified")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Login should be from {2} to {1} symbols")]
        public string Login { get; set; }

        [Display(Name = "Password", Prompt = "Password")]
        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name not specified")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Name should be from {2} to {1} symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname not specified")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Surname should be from {2} to {1} symbols")]
        public string Surname { get; set; }

        [Display(Name = "Age", Prompt = "Age")]
        [Required(ErrorMessage = "Age not specified")]
        [Range(16, 100, ErrorMessage = "Age should be from {1} to {2} years")]
        public int Age { get; set; }

        [Display(Name = "Phone", Prompt = "Phone")]
        [Required(ErrorMessage = "Phone not specified")]
        public string Phone { get; set; }
    }
}
