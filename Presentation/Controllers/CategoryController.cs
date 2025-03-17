using Application.Model.Category;
using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [Authorize(Policy = "RequireAdminRole")]
    [HttpGet("GetAllCategories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var res = await _categoryService.GetAllCategoriesAsync();
        return Ok(res);
    }
    [Authorize(Policy = "RequireAdminRole")]
    [HttpGet("GetCategory/{id}")]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        var res = await _categoryService.GetByIdCategoryAsync(id);
        return Ok(res);
    }
    [Authorize(Policy = "RequireAdminRole")]
    [HttpPost("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CategoryCM categoryCM)
    {
        var res = await _categoryService.CreateCategoryAsync(categoryCM);
        return Ok(res);
    }
    [Authorize(Policy = "RequireAdminRole")]
    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> UpdateCategory(CategoryUM categoryUM)
    {
        var res = await _categoryService.UpdateCategoryAsync(categoryUM);
        return Ok(res);
    }
    [Authorize(Policy = "RequireAdminRole")]
    [HttpDelete("DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var res = await _categoryService.DeleteCategoryAsync(id);
        return Ok(res);
    }
}

