using AutoMapper;
using EcommerceApi.Application;
using EcommerceApi.Domain;
using EcommerceApi.Domain.Dto;
using EcommerceApi.Infrastructure.Repository;
using EcommerceApi.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceTests;

public class ProductServiceTests
{
    private readonly IMapper _mapper;

    public ProductServiceTests()
    {
        // Use the real DI container like Program.cs
        var services = new ServiceCollection();

        // Required for AutoMapper 15+ (logging is mandatory)
        services.AddLogging();

        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<AutoMapperProfiles>();
        });

        var provider = services.BuildServiceProvider();
        _mapper = provider.GetRequiredService<IMapper>();
    }

    private AppDbContext BuildDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // isolated DB
            .Options;

        var context = new AppDbContext(options);

        context.Products.AddRange(new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Mouse",
                Description = "Test description",
                Price = 10m,
                StockQuantity = 5,
                IsActive = true
            },
            new Product
            {
                Id = 2,
                Name = "Keyboard",
                Description = "Test description",
                Price = 15m,
                StockQuantity = 10,
                IsActive = false
            },
            new Product
            {
                Id = 3,
                Name = "Monitor",
                Description = "Test description",
                Price = 20m,
                StockQuantity = 2,
                IsActive = true
            }
        });

        context.SaveChanges();
        return context;
    }

    [Fact]
    public async Task GetActiveProductsAsync_ShouldReturnOnlyActiveProducts()
    {
        // Arrange
        var db = BuildDbContext();
        var service = new ProductService(db, _mapper);

        // Act
        var result = await service.GetActiveProductsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<ProductDto>>(result);
        Assert.Equal(2, result.Count);

        Assert.DoesNotContain(result, p => p.Name == "Keyboard");
        Assert.Contains(result, p => p.Name == "Mouse");
        Assert.Contains(result, p => p.Name == "Monitor");
    }
}
