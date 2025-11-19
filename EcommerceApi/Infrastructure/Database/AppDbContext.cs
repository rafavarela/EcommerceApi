using EcommerceApi.Domain;
using EcommerceApi.Infrastructure.Database.Seed;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Infrastructure.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products", schema: "gral");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
            entity.Property(p => p.Name).IsRequired().HasMaxLength(80);
            entity.Property(p => p.Description).IsRequired().HasMaxLength(120);
            entity.Property(p => p.Price).IsRequired();
            entity.Property(p => p.StockQuantity).IsRequired();
            entity.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

            entity.HasData(ProductSeedData.GetData());
        });
    }
}
