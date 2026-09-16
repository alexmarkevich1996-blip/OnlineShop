using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Interfaces;
using Serilog;
using OnlineShop.Data.InMemory;
using OnlineShop.Data.MSSqlServer;

namespace OnlineShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddTransient<ICartsRepository, CartsDbRepository>();
            services.AddTransient<IProductsRepository, ProductsDbRepository>();
            services.AddSingleton<IOrdersRepository, InMemoryOrdersRepository>();
            services.AddTransient<IFavoritesRepository, FavoritesDbRepository>();
            services.AddTransient<IComparisonsRepository, ComparisonsDbRepository>();
            services.AddSingleton<IRolesRepository, InMemoryRolesRepository>();
            services.AddSingleton<IUsersRepository, InMemoryUsersRepository>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            app.UseDeveloperExceptionPage();

            app.UseSerilogRequestLogging();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

}