using OnlineShop.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class DeliveryUser
    {
        public Guid Id { get; set; }

        [Display(Name = "Buyer's name", Prompt = "Your name")]
        [Required(ErrorMessage = "Buyer's name not specified")]
        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Name should be from {2} to {1}")]
        public required string Name { get; set; }

        [Display(Name = "Delivery address", Prompt = "Your address")]
        [Required(ErrorMessage = "Delivery address not specified")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Delivery address should be from {2} to {1}")]
        public string Address { get; set; }

        [Display(Name = "Phone", Prompt = "Your phone")]
        [Required(ErrorMessage = "Buyer's phone not specified")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Phone number should contain only digits")]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Phone number should be from {2} to {1}")]
        public required string Phone { get; set; }


        [Display(Name = "Delivery Date")]
        [Required(ErrorMessage = "Delivery date not specified")]
        [DataType(DataType.Date)]
        [DateRangeAtrribute()]
        public DateTime Date { get; set; }

        [Display(Name = "Comment", Prompt = "Your comment")]
        [MaxLength(512, ErrorMessage = "Maximum length of the commment should not be over 512 symbols")]
        [DataType(DataType.MultilineText)]
        public string? Comment { get; set; }
    }
}
