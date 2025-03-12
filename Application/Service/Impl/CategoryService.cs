using Application.Model;
using Application.Model.Category;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Service.Impl;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly AudiobookDbContext _dbContext;

    public CategoryService(IMapper mapper, AudiobookDbContext context)
    {
        _mapper = mapper;
        _dbContext = context;
    }

    public async Task<ApiResult<CategoryCMResponse>> CreateCategoryAsync(CategoryCM model)
    {
        var category = _mapper.Map<Category>(model);
        category.CreatedOn = DateTime.UtcNow;
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();

        return ApiResult<CategoryCMResponse>.Success(new CategoryCMResponse { Id = category.Id });
    }

    public async Task<ApiResult<bool>> DeleteCategoryAsync(Guid id)
    {
        var category = _dbContext.Categories.FirstOrDefault(t => t.Id == id);
        if (category == null)
        {
            return ApiResult<bool>.Failure(new List<string> { "Category not found" });
        }

        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();

        return ApiResult<bool>.Success(true);
    }

    public async Task<ApiResult<IEnumerable<CategoryRM>>> GetAllCategoriesAsync()
    {
        var categories = await _dbContext.Categories
                                          .AsNoTracking()
                                          .ProjectTo<CategoryRM>(_mapper.ConfigurationProvider)
                                          .ToListAsync();
        return ApiResult<IEnumerable<CategoryRM>>.Success(categories);
    }

    public async Task<ApiResult<CategoryRM>> GetByIdCategoryAsync(Guid id)
    {
        var category = await _dbContext.Categories
                                         .AsNoTracking()
                                         .ProjectTo<CategoryRM>(_mapper.ConfigurationProvider)
                                         .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return ApiResult<CategoryRM>.Failure(new List<string> { "Category not found" });
        }

        return ApiResult<CategoryRM>.Success(category);
    }

    public async Task<ApiResult<CategoryUMResponse>> UpdateCategoryAsync(CategoryUM model)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(s => s.Id == model.Id);

        if (category == null)
        {
            return ApiResult<CategoryUMResponse>.Failure(new List<string> { "Category not found" });
        }

        _mapper.Map(model, category);
        category.UpdatedOn = DateTime.UtcNow;
        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync();

        return ApiResult<CategoryUMResponse>.Success(new CategoryUMResponse { Id = category.Id });
    }
}

