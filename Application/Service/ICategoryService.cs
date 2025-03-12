using Application.Model;
using Application.Model.Category;

namespace Application.Service;

public interface ICategoryService
{
    Task<ApiResult<CategoryCMResponse>> CreateCategoryAsync(CategoryCM model);
    Task<ApiResult<CategoryRM>> GetByIdCategoryAsync(Guid id);
    Task<ApiResult<IEnumerable<CategoryRM>>> GetAllCategoriesAsync();
    Task<ApiResult<CategoryUMResponse>> UpdateCategoryAsync(CategoryUM model);
    Task<ApiResult<bool>> DeleteCategoryAsync(Guid id);
}

