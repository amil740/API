using AutoMapper;
using OnionArchitecture.Application.Dtos;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Category mappings
            CreateMap<Category, CategoryReturnDto>();
            CreateMap<CategoryCreateDto, Category>();
        }
    }
}
