using Microsoft.Extensions.DependencyInjection;
using OnlineShop.BLL.Interfaces;
using OnlineShop.BLL.Services;
using MyOnlineShop.DAL.Interfaces;
using MyOnlineShop.DAL.Repositories;
using AutoMapper;
using OnlineShop.BLL.Mapping;

namespace OnlineShop.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            // Добавьте другие репозитории
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrdersService, OrdersService>();
            // Добавьте другие сервисы
        }

        public static void AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
