using Microsoft.EntityFrameworkCore;
using OnlineShop.BLL.Interfaces;
using OnlineShop.BLL.DTO.RequestDTO.UsersRequestDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.BLL.Services;
using OnlineShop.DAL.Interfaces;
using OnlineShop.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Text;
using OnlineShop.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

// Minimal API endpoints
app.MapPost("/api/auth/register", async (IAuthService authService, UserRegisterDTO model) =>
{
    var result = await authService.RegisterAsync(model);
    if (!result.Success)
    {
        return Results.BadRequest(result.Errors);
    }
    return Results.Ok(result);
}).AllowAnonymous();

app.MapPost("/api/auth/login", async (IAuthService authService, UserLoginDTO model) =>
{
    var result = await authService.LoginAsync(model);
    if (!result.Success)
    {
        return Results.BadRequest(result.Errors);
    }
    return Results.Ok(result);
}).AllowAnonymous();

app.MapGet("/api/test", async () =>
{
    return Results.Ok("Hello, Minimal API with JWT Authentication!");
}).RequireAuthorization();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
