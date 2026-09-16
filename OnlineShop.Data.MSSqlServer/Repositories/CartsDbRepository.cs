using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Interfaces;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.MSSqlServer.Repositories
{
    public class CartsDbRepository(DatabaseContext dbContext) : ICartsRepository
    {
        public Cart? TryGetByUserId(string userId)
        {
             
            return dbContext.Carts                                                                                                                                                                                                       
                .Include(c => c.Items)                                                                                                                                                                                                   
                .ThenInclude(i => i.Product)                                                                                                                                                                                             
                .FirstOrDefault(cart => cart.UserId == userId);   
        }

        public void Add(Product? product, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart == null)
            {
                existingCart = new Cart()
                {
                    UserId = userId,
                    Items = 
                    [
                         new CartItem()
                         {
                           Product = product,
                           Quantity = 1
                         }
                    ]
                };
                dbContext.Carts.Add(existingCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(item => item.Product.Id == product.Id);

                if(existingCartItem == null)
                {
                    var newCartItem = new CartItem()
                    {
                        Product = product,
                        Quantity = 1
                    };
                    existingCart.Items.Add(newCartItem);
                }
                else
                {
                    existingCartItem.Quantity++;
                }
            }
            dbContext.SaveChanges();
        }
        public void Subtract(Guid productId, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart!.Items.FirstOrDefault(item => item.Product.Id == productId);
            
            if(existingCartItem == null)
            {
                return;
            }

            existingCartItem.Quantity--;
            
            if(existingCartItem.Quantity == 0)
            {
                existingCart!.Items.Remove(existingCartItem);
            }
            
            dbContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if(existingCart != null)
            {
                dbContext.Carts.Remove(existingCart);
            }
            
            dbContext.SaveChanges();
        }
    }
}
