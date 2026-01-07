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
    public class ProductService(IApplicationDbContext context, IMapper mapper) : IProductService
    {
        public async Task<ApiResponse<IEnumerable<ProductReturnDto>>> GetAllProductsAsync()
        {
            var products = await context.Products.ToListAsync();
            var productDtos = mapper.Map<IEnumerable<ProductReturnDto>>(products);
            return ApiResponse<IEnumerable<ProductReturnDto>>.SuccessResult(productDtos);
        }

        public async Task<ApiResponse<ProductReturnDto>> GetProductByIdAsync(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product is null)
                throw new NotFoundException(nameof(Product), id);

            var productDto = mapper.Map<ProductReturnDto>(product);
            return ApiResponse<ProductReturnDto>.SuccessResult(productDto);
        }

        public async Task<ApiResponse<ProductReturnDto>> CreateProductAsync(ProductCreateDto createDto)
        {
            var category = await context.Categories.FindAsync(createDto.categoryid);

            if (category is null)
                throw new NotFoundException(nameof(Category), createDto.categoryid);

            var product = mapper.Map<Product>(createDto);

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            var productDto = mapper.Map<ProductReturnDto>(product);
            return ApiResponse<ProductReturnDto>.SuccessResult(productDto, "Product created successfully", 201);
        }

        public async Task<ApiResponse<ProductReturnDto>> UpdateProductAsync(int id, ProductCreateDto updateDto)
        {
            var product = await context.Products.FindAsync(id);

            if (product is null)
                throw new NotFoundException(nameof(Product), id);

            var category = await context.Categories.FindAsync(updateDto.categoryid);

            if (category is null)
                throw new NotFoundException(nameof(Category), updateDto.categoryid);

            product.Name = updateDto.name;
            product.Price = updateDto.price;
            product.CategoryId = updateDto.categoryid;

            await context.SaveChangesAsync();

            var productDto = mapper.Map<ProductReturnDto>(product);
            return ApiResponse<ProductReturnDto>.SuccessResult(productDto, "Product updated successfully");
        }

        public async Task<ApiResponse> DeleteProductAsync(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product is null)
                throw new NotFoundException(nameof(Product), id);

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return ApiResponse.SuccessResult("Product deleted successfully");
        }
    }
}
