using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin.ViewModels
{
    public class RoleViewModel
    {
        public string? Id { get; set; }

        [Display(Name = "Role Name", Prompt = "Role Name")]
        [Required(ErrorMessage = "Role name not specified")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Role Name should from {2} to {1} symbols")]
        public string Name { get; set; }
    }
}
