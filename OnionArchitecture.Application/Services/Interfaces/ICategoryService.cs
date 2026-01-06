using OnionArchitecture.Application.Dtos;

namespace OnionArchitecture.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryCreateDto>> GetAllCategoriesAsync();
        Task<CategoryCreateDto> CreateCategoryAsync(CategoryCreateDto createDto);
    }
}
