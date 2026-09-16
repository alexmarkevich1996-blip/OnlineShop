using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Core.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        
        public Cart? Cart { get; set; }
        public int Quantity { get; set; }
        
        [NotMapped]
        public decimal Cost => Product.Cost * Quantity;
    }
}