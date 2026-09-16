using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.MSSqlServer
{
    public class FavoritesDbRepository(DatabaseContext dbContext) : IFavoritesRepository
    {
        public Favorite? TryGetByUserId(string userId)
        {
            return dbContext.Favorites
                .Include(f => f.Items)
                .FirstOrDefault(f => f.UserId == userId);
        }
        public void Add(Product product, string userId)
        {
            var favorite = TryGetByUserId(userId);

            if (favorite == null)
            {
                favorite = new Favorite()
                {
                    UserId = userId,
                    Items = [product]
                };
                dbContext.Favorites.Add(favorite);
            }
            else
            {
                var existingFavoriteItem = favorite.Items.FirstOrDefault(item => item.Id == product.Id);

                if(existingFavoriteItem is null)
                {
                    favorite.Items.Add(product);
                }
            }
            
            dbContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var favorite = TryGetByUserId(userId);

            if(favorite != null)
            {
                dbContext.Favorites.Remove(favorite);
            }
            dbContext.SaveChanges();
        }

        public void Remove(Guid productId, string userId)
        {
            var favorite = TryGetByUserId(userId);

            if(favorite != null)
            {
                favorite?.Items.RemoveAll(item => item.Id == productId);
            }
            
            dbContext.SaveChanges();

        }
    }
}
