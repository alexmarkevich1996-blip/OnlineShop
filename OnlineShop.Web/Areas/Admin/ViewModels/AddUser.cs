using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin.ViewModels
{
    public class AddUser
    {
        [Display(Name = "Login", Prompt = "Login")]
        public string Login { get; set; }

        [Display(Name = "Password", Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [Display(Name = "Age", Prompt = "Age")]
        public int Age { get; set; }

        [Display(Name = "Phone", Prompt = "Phone")]
        public string Phone { get; set; }
    }
}
