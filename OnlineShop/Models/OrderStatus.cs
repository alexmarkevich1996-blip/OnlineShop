using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Created")]
        Created,

        [Display(Name = "Processed")]
        Processed,

        [Display(Name = "Delivering")]
        Delivering,

        [Display(Name = "Delivered")]
        Delivered,

        [Display(Name = "Cancelled")]
        Cancelled
    }
}
