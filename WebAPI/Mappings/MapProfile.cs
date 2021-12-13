using AutoMapper;
using Core.Models;
using WebAPI.Dtos;

namespace WebAPI.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithProductsDto>();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductWithCategoryDto>();
        }
    }
}
