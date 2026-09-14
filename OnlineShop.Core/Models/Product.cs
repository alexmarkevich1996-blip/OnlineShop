using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Core.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string? Description { get; set; } 
        public string PhotoPath { get; set; } = "/img/anyProduct.png ";
        
        public Product() { }

        public Product(Guid id, string name, decimal cost, string? description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Id}{Environment.NewLine}{Name}{Environment.NewLine}{Cost:c}";
        }
    }
}
