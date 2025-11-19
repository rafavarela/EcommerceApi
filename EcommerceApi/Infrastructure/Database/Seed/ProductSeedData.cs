using EcommerceApi.Domain;

namespace EcommerceApi.Infrastructure.Database.Seed;

public static class ProductSeedData
{
    public static List<Product> GetData()
    {
        return new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Wireless Mouse",
                Description = "Ergonomic wireless mouse with adjustable DPI.",
                Price = 29.99m,
                StockQuantity = 150,
                IsActive = true
            },
            new Product
            {
                Id = 2,
                Name = "Mechanical Keyboard",
                Description = "RGB backlit mechanical keyboard with blue switches.",
                Price = 79.99m,
                StockQuantity = 80,
                IsActive = true
            },
            new Product
            {
                Id = 3,
                Name = "HD Monitor",
                Description = "24-inch full HD monitor with ultra-thin bezels.",
                Price = 149.99m,
                StockQuantity = 60,
                IsActive = true
            },
            new Product
            {
                Id = 4,
                Name = "USB-C Hub",
                Description = "Multi-port USB-C hub with HDMI and Ethernet.",
                Price = 49.99m,
                StockQuantity = 200,
                IsActive = false
            },
            new Product
            {
                Id = 5,
                Name = "External Hard Drive",
                Description = "1TB portable external hard drive with USB 3.0.",
                Price = 59.99m,
                StockQuantity = 120,
                IsActive = true
            }
        };
    }
}
