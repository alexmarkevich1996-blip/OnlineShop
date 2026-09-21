using OnlineShop.Core.Models;

namespace OnlineShop.Areas.Admin.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public decimal? TotalCost { get; set; }
        public int? ItemsQuantity { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DeliveryUser DeliveryUser { get; set; }
        public List<CartItem> Items { get; set; } = [];
    }
}
