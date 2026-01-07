using AutoMapper;
using OnionArchitecture.Application.Dtos;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryReturnDto>();
            CreateMap<CategoryCreateDto, Category>();

            CreateMap<Product, ProductReturnDto>()
                .ForCtorParam("categoryid", opt => opt.MapFrom(src => src.CategoryId));
            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.categoryid))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.price));
        }
    }
}
