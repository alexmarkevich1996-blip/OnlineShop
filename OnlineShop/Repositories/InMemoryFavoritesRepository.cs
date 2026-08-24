using OnlineShop.Interfaces;
using OnlineShop.Models;

namespace OnlineShop.Repositories
{
    public class InMemoryFavoritesRepository : IFavoritesRepository
    {
        private readonly List<Favorite> _favorites = [];

        public Favorite? TryGetByUserId(string userId)
        {
            return _favorites.FirstOrDefault(f => f.UserId == userId);
        }
        public void Add(Product product, string userId)
        {
            var favorite = TryGetByUserId(userId);

            if (favorite == null)
            {
                favorite = new Favorite()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = [product]
                };
                _favorites.Add(favorite);
            }
            else
            {
                var existingFavoriteItem = favorite.Items.FirstOrDefault(item => item.Id == product.Id);

                if(existingFavoriteItem is null)
                {
                    favorite.Items.Add(product);
                }
            }
        }

        public void Clear(string userId)
        {
            var favorite = TryGetByUserId(userId);

            if(favorite != null)
            {
                _favorites.Remove(favorite);
            }
        }

        public void Remove(int productId, string userId)
        {
            var favorite = TryGetByUserId(userId);

            if(favorite != null)
            {
                favorite?.Items.RemoveAll(item => item.Id == productId);
            }

        }
    }
}
