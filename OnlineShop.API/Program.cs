using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Регистрация сервисов и настройка зависимостей
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

// Настройка HTTP конвейера запросов
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Добавление маршрутов и использование контроллеров
app.UseRouting();

// Добавление авторизации и аутентификации
app.UseAuthentication();
app.UseAuthorization();

// Добавление Endpoints (контроль над контроллерами и их маршрутами)
app.MapControllers();

// Запуск приложения
app.Run();
