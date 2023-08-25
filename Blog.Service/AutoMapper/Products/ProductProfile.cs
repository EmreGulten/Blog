using AutoMapper;
using Blog.Entity.DTOs.Products;
using Blog.Entity.Entities;

namespace Blog.Service.AutoMapper.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, ProductDto>().ReverseMap();
            CreateMap<ProductAddDto, Product>().ReverseMap();
        }
    }
}
