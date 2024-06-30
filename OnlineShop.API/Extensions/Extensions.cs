using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.BLL.Interfaces;
using OnlineShop.BLL.Services;
using OnlineShop.DAL.Interfaces;
using OnlineShop.DAL.Repositories;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using OnlineShop.BLL.Validations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OnlineShop.BLL.DTO.RequestDTO.CategoryRequestDTO;
using OnlineShop.API.Filters;

namespace OnlineShop.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<OnlineShopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            /// Add Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // Add Services
            services.AddScoped<IAuthService, AuthService>();

            // Add Validators
            // // Uncomment when services appear
            // services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();

            services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilter>();
            });

            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

            var key = Encoding.ASCII.GetBytes(configuration["JwtConfig:Secret"]);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {   
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
            });
        }
    }
}