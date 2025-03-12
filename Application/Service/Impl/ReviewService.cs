using Application.Model.Review;
using Application.Model;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.Service.Impl;

public class ReviewService : IReviewService
{
    private readonly IMapper _mapper;
    private readonly AudiobookDbContext _dbContext;

    public ReviewService(IMapper mapper, AudiobookDbContext context)
    {
        _mapper = mapper;
        _dbContext = context;
    }

    public async Task<ApiResult<ReviewCMResponce>> CreateReviewAsync(ReviewCM model)
    {
        var review = _mapper.Map<Review>(model);
        review.CreatedOn = DateTime.UtcNow;

        _dbContext.Reviews.Add(review);
        await _dbContext.SaveChangesAsync();

        return ApiResult<ReviewCMResponce>.Success(new ReviewCMResponce
        {
            Id = review.Id
        });
    }

    public async Task<ApiResult<bool>> DeleteReviewAsync(Guid id)
    {
        var review = _dbContext.Reviews.FirstOrDefault(t => t.Id == id);
        if (review == null)
        {
            return ApiResult<bool>.Failure(new List<string> { "Review not found" });
        }

        _dbContext.Reviews.Remove(review);
        await _dbContext.SaveChangesAsync();

        return ApiResult<bool>.Success(true);
    }

    public async Task<ApiResult<IEnumerable<ReviewRM>>> GetAllReviewsAsync()
    {
        var reviews = await _dbContext.Reviews
                                      .AsNoTracking()
                                      .ProjectTo<ReviewRM>(_mapper.ConfigurationProvider)
                                      .ToListAsync();

        return ApiResult<IEnumerable<ReviewRM>>.Success(reviews);
    }

    public async Task<ApiResult<ReviewRM>> GetByIdReviewAsync(Guid id)
    {
        var review = await _dbContext.Reviews
                                     .AsNoTracking()
                                     .ProjectTo<ReviewRM>(_mapper.ConfigurationProvider)
                                     .FirstOrDefaultAsync(c => c.Id == id);

        if (review == null)
        {
            return ApiResult<ReviewRM>.Failure(new List<string> { "Review not found" });
        }

        return ApiResult<ReviewRM>.Success(review);
    }

    public async Task<ApiResult<ReviewUMResponce>> UpdateReviewAsync(ReviewUM model)
    {
        var review = await _dbContext.Reviews.FirstOrDefaultAsync(s => s.Id == model.Id);

        if (review == null)
        {
            return ApiResult<ReviewUMResponce>.Failure(new List<string> { "Review not found" });
        }

        _mapper.Map(model, review);
        review.UpdatedOn = DateTime.UtcNow;

        _dbContext.Reviews.Update(review);
        await _dbContext.SaveChangesAsync();

        return ApiResult<ReviewUMResponce>.Success(new ReviewUMResponce
        {
            Id = review.Id
        });
    }
}

