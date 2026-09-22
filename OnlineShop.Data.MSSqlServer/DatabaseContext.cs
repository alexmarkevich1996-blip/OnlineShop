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
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Cost)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Trousers",
                Cost = 999.99m,
                Description = "Desc1",
                PhotoPath = "/img/anyProduct.png"
            },
            new Product
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "Jacket",
                Cost = 599.99m,
                Description = "Desc1",
                PhotoPath = "/img/anyProduct.png"
            },
            new Product
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Shoes",
                Cost = 149.99m,
                Description = "Desc2",
                PhotoPath = "/img/anyProduct.png"
            },
            new Product
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Name = "T-Shirt",
                Cost = 249.99m,
                Description = "Desc3",
                PhotoPath = "/img/anyProduct.png"
            }
        );

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

        modelBuilder.Entity<DeliveryUser>(builder =>
        {
            builder.Property(d => d.Name).HasMaxLength(25);
            builder.Property(d => d.Address).HasMaxLength(100);
            builder.Property(d => d.Phone).HasMaxLength(16);
            builder.Property(d => d.Comment).HasMaxLength(512);
        });
    }
}