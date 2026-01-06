using OnionArchitecture.Application.Common.Models;
using OnionArchitecture.Application.Dtos;

namespace OnionArchitecture.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResponse<IEnumerable<CategoryReturnDto>>> GetAllCategoriesAsync();
        Task<ApiResponse<CategoryReturnDto>> CreateCategoryAsync(CategoryCreateDto createDto);
        Task<ApiResponse<CategoryReturnDto>> GetCategoryByIdAsync(int id);
        Task<ApiResponse> DeleteCategoryAsync(int id);
    }
}
