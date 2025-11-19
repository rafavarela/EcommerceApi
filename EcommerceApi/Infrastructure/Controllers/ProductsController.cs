using EcommerceApi.Application;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Infrastructure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetActiveProducts()
    {
        var products = await _productService.GetActiveProductsAsync();
        return Ok(products);
    }
}
