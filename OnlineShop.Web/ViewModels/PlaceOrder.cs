using OnlineShop.Core.Models;

namespace OnlineShop.ViewModels
{
    public class PlaceOrder
    {
        public DeliveryUser DeliveryUser { get; set; }
        public List<CartItem> Items { get; set; } = [];
        public decimal? TotalCost => Items.Sum(item => item.Cost);
    }
}
