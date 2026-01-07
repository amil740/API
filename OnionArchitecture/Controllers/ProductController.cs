using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Dtos;
using OnionArchitecture.Application.Services.Interfaces;

namespace OnionArchitecture.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await productService.GetAllProductsAsync();
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var response = await productService.GetProductByIdAsync(id);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto createDto)
    {
        var response = await productService.CreateProductAsync(createDto);
        return StatusCode(response.StatusCode, response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await productService.DeleteProductAsync(id);
        return StatusCode(response.StatusCode, response);
    }
}
