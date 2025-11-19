using EcommerceApi.Domain.Dto;

namespace EcommerceApi.Application;

public interface IProductService
{
    Task<List<ProductDto>> GetActiveProductsAsync();
}
