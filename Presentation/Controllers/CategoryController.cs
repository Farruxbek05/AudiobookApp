using Application.Model.Category;
using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("GetAllCategories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var res = await _categoryService.GetAllCategoriesAsync();
        return Ok(res);
    }

    [HttpGet("GetCategory/{id}")]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        var res = await _categoryService.GetByIdCategoryAsync(id);
        return Ok(res);
    }

    [HttpPost("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CategoryCM categoryCM)
    {
        var res = await _categoryService.CreateCategoryAsync(categoryCM);
        return Ok(res);
    }

    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> UpdateCategory(CategoryUM categoryUM)
    {
        var res = await _categoryService.UpdateCategoryAsync(categoryUM);
        return Ok(res);
    }

    [HttpDelete("DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var res = await _categoryService.DeleteCategoryAsync(id);
        return Ok(res);
    }
}

