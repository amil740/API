using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Common.Exceptions;
using OnionArchitecture.Application.Common.Models;
using OnionArchitecture.Application.Dtos;
using OnionArchitecture.Application.Interfaces;
using OnionArchitecture.Application.Services.Interfaces;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Application.Services.Implementations
{
    public class CategoryService(IApplicationDbContext context, IMapper mapper) : ICategoryService
    {
        public async Task<ApiResponse<IEnumerable<CategoryReturnDto>>> GetAllCategoriesAsync()
        {
            var categories = await context.Categories.ToListAsync();
            var categoryDtos = mapper.Map<IEnumerable<CategoryReturnDto>>(categories);
            return ApiResponse<IEnumerable<CategoryReturnDto>>.SuccessResult(categoryDtos);
        }

        public async Task<ApiResponse<CategoryReturnDto>> GetCategoryByIdAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);
            
            if (category is null)
                throw new NotFoundException(nameof(Category), id);

            var categoryDto = mapper.Map<CategoryReturnDto>(category);
            return ApiResponse<CategoryReturnDto>.SuccessResult(categoryDto);
        }

        public async Task<ApiResponse<CategoryReturnDto>> CreateCategoryAsync(CategoryCreateDto createDto)
        {
            var category = mapper.Map<Category>(createDto);
            
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            var categoryDto = mapper.Map<CategoryReturnDto>(category);
            return ApiResponse<CategoryReturnDto>.SuccessResult(categoryDto, "Category created successfully", 201);
        }

        public async Task<ApiResponse> DeleteCategoryAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);
            
            if (category is null)
                throw new NotFoundException(nameof(Category), id);

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return ApiResponse.SuccessResult("Category deleted successfully");
        }
    }
}
