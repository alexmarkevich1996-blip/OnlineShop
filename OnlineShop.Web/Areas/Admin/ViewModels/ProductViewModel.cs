using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin.ViewModels;

public class ProductViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "Product Name", Prompt = "Product name")]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [Display(Name = "Product Cost", Prompt = "Product Cost")]
    public decimal Cost { get; set; }

    [Display(Name = "Product Description", Prompt = "Product Description")]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    public string PhotoPath { get; set; } = "/img/anyProduct.png ";
}
