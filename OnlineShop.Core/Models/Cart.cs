
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Core.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        
        [NotMapped]
        public decimal TotalCost => Items.Sum(x => x.Cost);
        [NotMapped]
        public int Quantity => Items.Sum(x => x.Quantity);

        public Cart()
        {
            Items = new List<CartItem>();
        }
    }
}
