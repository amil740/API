using OnionArchitecture.Application.Common.Models;
using OnionArchitecture.Application.Dtos;

namespace OnionArchitecture.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponse<IEnumerable<ProductReturnDto>>> GetAllProductsAsync();
        Task<ApiResponse<ProductReturnDto>> GetProductByIdAsync(int id);
        Task<ApiResponse<ProductReturnDto>> CreateProductAsync(ProductCreateDto createDto);
        Task<ApiResponse<ProductReturnDto>> UpdateProductAsync(int id, ProductCreateDto updateDto);
        Task<ApiResponse> DeleteProductAsync(int id);
    }
}
