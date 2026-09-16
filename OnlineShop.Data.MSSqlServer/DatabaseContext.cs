using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.MSSqlServer;

public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Comparison> Comparisons { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Cart)
            .WithMany(c => c.Items)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<Favorite>()
            .HasMany(f => f.Items)
            .WithMany();
        
        modelBuilder.Entity<Comparison>()
            .HasMany(f => f.Items)
            .WithMany();
        
        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithMany();
    }
}