using OnlineShop.Core.Models;

namespace OnlineShop.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> Items { get; set; } = [];
        public decimal TotalCost => Items.Sum(item => item.Cost);
    }
}
