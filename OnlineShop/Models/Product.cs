namespace OnlineShop.Models
{
    public record Product(int Id, string Name, decimal Cost, string? Description)
    {
        public string PhotoPath { get; set; } = "/img/anyProduct.png";
        public override string ToString()
        {
            return $"{Id}{Environment.NewLine}{Name}{Environment.NewLine}{Cost:c}";
        }
    }
}
