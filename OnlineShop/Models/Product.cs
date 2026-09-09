using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Product Name", Prompt = "Product name")]
        [Required(ErrorMessage = "Product name not specified")]
        [DataType(DataType.Text)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Name should be from {2} to {1}")]
        public string Name { get; set; }

        [Display(Name = "Product Cost", Prompt = "Product Cost")]
        [Required(ErrorMessage = "Product cost not specified")]
        [Range(0, 1_000_000, ErrorMessage = "Product cost should be from {2} to {1}")]
        public decimal Cost { get; set; } 

        [Display(Name = "Product Description", Prompt = "Product Description")]
        [MaxLength(4096, ErrorMessage = "Maximum length of product description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; } 

        [Required]
        public string PhotoPath { get; set; } = "/img/anyProduct.png ";
        
        public Product() { }

        public Product(int id, string name, decimal cost, string? description)
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
