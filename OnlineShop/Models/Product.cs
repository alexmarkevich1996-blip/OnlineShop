namespace OnlineShop.Models
{
    public record Product(int Id, string Name, decimal Cost, string? Description)
    {
        public override string ToString()
        {
            return $"{Id}{Environment.NewLine}{Name}{Environment.NewLine}{Cost:c}";
        }
    }
}
