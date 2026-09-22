using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin.ViewModels
{
    public class RoleViewModel
    {
        public string? Id { get; set; }

        [Display(Name = "Role Name", Prompt = "Role Name")]
        public string Name { get; set; }
    }
}
