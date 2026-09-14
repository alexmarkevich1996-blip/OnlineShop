using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Core.Models
{
    public class Order
    {
        [Required]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }

        [Required]
        public DeliveryUser DeliveryUser { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
        public DateTime CreationDateTime { get; set; }
        public decimal? TotalCost => Items?.Sum(item => item.Cost);
        public int? ItemsQuantity => Items?.Sum(item => item.Quantity);
    }
}
