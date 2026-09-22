using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Login", Prompt = "Login")]
        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [Display(Name = "Age", Prompt = "Age")]
        public int Age { get; set; }

        [Display(Name = "Phone", Prompt = "Phone")]
        public string Phone { get; set; }

        public string? Role { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
