using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// ����������� �������� � ��������� ������������
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

// ��������� HTTP ��������� ��������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ���������� ��������� � ������������� ������������
app.UseRouting();

// ���������� ����������� � ��������������
app.UseAuthentication();
app.UseAuthorization();

// ���������� Endpoints (�������� ��� ������������� � �� ����������)
app.MapControllers();

// ������ ����������
app.Run();
