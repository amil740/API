using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Dtos;
using OnionArchitecture.Application.Services.Interfaces;

namespace OnionArchitecture.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var response = await categoryService.GetAllCategoriesAsync();
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var response = await categoryService.GetCategoryByIdAsync(id);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateDto createDto)
    {
        var response = await categoryService.CreateCategoryAsync(createDto);
        return StatusCode(response.StatusCode, response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await categoryService.DeleteCategoryAsync(id);
        return StatusCode(response.StatusCode, response);
    }
}
