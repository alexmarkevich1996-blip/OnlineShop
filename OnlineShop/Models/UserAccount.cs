using OnlineShop.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class UserAccount
    {
        
        public Guid Id { get; set; }

        [Display(Name = "Login", Prompt = "Your login")]
        [Required(ErrorMessage = "Login not specified")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name not specified")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "The length should be from {2} to {1} symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname not specified")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "The length should be from {2} to {1} symbols")]
        public string Surname { get; set; }

        [Display(Name = "Age", Prompt = "Your age")]
        [Required(ErrorMessage = "Age not specified")]
        [Range(16, 100, ErrorMessage = "Age should be from {1} to {2} years")]
        public int Age { get; set; }

        [Display(Name = "Phone", Prompt = "Your phone")]
        [Required(ErrorMessage = "Phone not specified")]
        public string Phone { get; set; }
        
        public DateTime CreationDateTime { get; internal set; }
    }
}
