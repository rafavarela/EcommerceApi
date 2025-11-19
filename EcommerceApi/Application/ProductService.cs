using AutoMapper;
using EcommerceApi.Domain.Dto;
using EcommerceApi.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Application;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProductService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> GetActiveProductsAsync()
    {
        var activeProducts = await _context.Products
            .Where(p => p.IsActive)
            .ToListAsync();

        return _mapper.Map<List<ProductDto>>(activeProducts);
    }
}
