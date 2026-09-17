
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Core.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public DateTime CreatedDateTime { get; set; }
        
        [NotMapped]
        public decimal TotalCost => Items.Sum(x => x.Cost);
        [NotMapped]
        public int Quantity => Items.Sum(x => x.Quantity);

        public Cart()
        {
            Items = new List<CartItem>();
            CreatedDateTime = DateTime.Now;
        }
    }
}
