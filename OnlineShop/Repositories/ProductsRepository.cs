using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public static class ProductsRepository
    {
        private static int _instanceCounter = 0;
        private static readonly List<Product> _products =
            [
                new Product(++_instanceCounter, "T-Shirt", 1000, "Luxury shirt from Dolce&Gabana"),
                new Product(++_instanceCounter, "Jacket", 2000, "Mind-blowing jacket from H&M"),
                new Product(++_instanceCounter, "Sneackers shoes", 3500, "Elegant shoes from ECCO"),
                new Product(++_instanceCounter, "Trousers", 5000, "Amazing trousers from Beneton")
            ];

        public static List<Product> GetAll() => _products;

        public static Product? TryGetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}
