using AutoMapper;
using EcommerceApi.Domain;
using EcommerceApi.Domain.Dto;

namespace EcommerceApi.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Product, ProductDto>();
    }
}
