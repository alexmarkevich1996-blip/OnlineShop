using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Core.Models
{
    public class DeliveryUser
    {
        public Guid Id { get; set; }

        [Display(Name = "Buyer's name", Prompt = "Your name")]
        [DataType(DataType.Text)]
        public required string Name { get; set; }

        [Display(Name = "Delivery address", Prompt = "Your address")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Display(Name = "Phone", Prompt = "Your phone")]
        [DataType(DataType.PhoneNumber)]
        public required string Phone { get; set; }

        [Display(Name = "Delivery Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Comment", Prompt = "Your comment")]
        [DataType(DataType.MultilineText)]
        public string? Comment { get; set; }
    }
}
