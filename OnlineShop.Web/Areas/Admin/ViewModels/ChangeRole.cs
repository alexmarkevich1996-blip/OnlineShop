using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop.Areas.Admin.ViewModels
{
    public class ChangeRole
    {
        [Display(Name = "Login", Prompt = "Your login")]
        [DataType(DataType.EmailAddress)]
        [AllowNull]
        public string Login { get; set; }

        [Display(Name = "Role")]
        [AllowNull]
        public string Role { get; set; }

        [AllowNull]
        public List<SelectListItem> Roles { get; set; }
    }
}
