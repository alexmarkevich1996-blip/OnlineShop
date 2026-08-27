namespace OnlineShop.Models
{
    public record Product(int Id, string Name, decimal Cost, string? Description)
    {
        public int Id { get; set; } = Id;
        public string Name { get; set; } = Name;
        public decimal Cost { get; set; } = Cost;
        public string? Description { get; set; } = Description;
        public string PhotoPath { get; set; } = "/img/anyProduct.png ";
        public override string ToString()
        {
            return $"{Id}{Environment.NewLine}{Name}{Environment.NewLine}{Cost:c}";
        }
    }
}
