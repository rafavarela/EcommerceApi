namespace EcommerceApi.Domain.Dto;

public record ProductDto
(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity
);
