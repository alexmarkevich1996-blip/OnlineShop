using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        [Display(Name = "Role Name", Prompt  = "Role Name")]
        [Required(ErrorMessage = "Role name not specified")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Role Name should from {2} to {1} symbols")]
        public required string Name { get; set; }

    }
}
