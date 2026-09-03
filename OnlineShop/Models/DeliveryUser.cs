using OnlineShop.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class DeliveryUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


        [Display(Name = "Delivery Date")]
        [Required(ErrorMessage = "Delivery date not specified")]
        [DataType(DataType.Date)]
        [DateRangeAtrribute()]
        public DateTime Date { get; set; }
        public string? Comment { get; set; }
    }
}
