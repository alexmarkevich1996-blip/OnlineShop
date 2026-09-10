using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Areas.Admin.Models
{
    public class ChangeRole
    {
        [Display(Name = "Login", Prompt = "Your login")]
        [Required(ErrorMessage = "Login not specified")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Login should be from {2} to {1} symbols")]
        [AllowNull]
        public string Login { get; set; }


        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role not specified")]
        [AllowNull]
        public string Role { get; set; }


        [AllowNull]
        public List<SelectListItem> Roles { get; set; }
    }
}
