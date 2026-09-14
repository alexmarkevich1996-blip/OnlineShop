using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;

namespace OnlineShop.Data.MSSqlServer;

public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();  
    }
    
    
}