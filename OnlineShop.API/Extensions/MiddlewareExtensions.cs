using Microsoft.AspNetCore.Builder;
using OnlineShop.Middlewares;

namespace OnlineShop.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ValidationMiddleware>();
            return app;
        }
    }
}
