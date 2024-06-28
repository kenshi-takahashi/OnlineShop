using Microsoft.Extensions.DependencyInjection;
using OnlineShop.BLL.Interfaces;
using OnlineShop.BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace OnlineShop.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Добавление DbContext
            services.AddDbContext<OnlineShopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Регистрация репозиториев и служб
            services.AddScoped<IOrdersService, OrdersService>(); // Ваш сервис OrdersService

    
            services.AddControllers();

     
            services.AddSwaggerGen();

      
        }
    }
}
