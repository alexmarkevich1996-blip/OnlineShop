using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels
{
    public class Registration
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [Display(Name = "Age", Prompt = "Your age")]
        public int Age { get; set; }

        [Display(Name = "Login", Prompt = "Your login")]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Display(Name = "Phone", Prompt = "Your phone")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
