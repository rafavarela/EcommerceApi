using EcommerceApi.Application;
using EcommerceApi.Infrastructure.Repository;
using EcommerceApi.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // OpenAPI docs: https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<AppDbContext>(options => {
            options.UseInMemoryDatabase("InMemoryDb");
        });

        builder.Services.AddAutoMapper(config => {
            config.LicenseKey = builder.Configuration["AutoMapper:LicenseKey"];
            config.AddProfile<AutoMapperProfiles>();
        });

        builder.Services.AddScoped<IProductService, ProductService>();

        var app = builder.Build(); // center

        // Ensure DB is created and seeded
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated(); // triggers HasData seeding
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
