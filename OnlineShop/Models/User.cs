using OnlineShop.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class User
    {
        
        public Guid Id { get; set; }

        [Display(Name = "Login", Prompt = "Your login")]
        [Required(ErrorMessage = "Login not specified")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Login should be from {2} to {1} symbols")]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Display(Name = "Password", Prompt = "Your password")]
        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name not specified")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Name should be from {2} to {1} symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname not specified")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Surname should be from {2} to {1} symbols")]
        public string Surname { get; set; }

        [Display(Name = "Age", Prompt = "Your age")]
        [Required(ErrorMessage = "Age not specified")]
        [Range(16, 100, ErrorMessage = "Age should be from {1} to {2} years")]
        public int Age { get; set; }

        [Display(Name = "Phone", Prompt = "Your phone")]
        [Required(ErrorMessage = "Phone not specified")]
        public string Phone { get; set; }

        public Role? Role { get; set; }
        
        public DateTime CreationDateTime { get; internal set; }
    }
}
