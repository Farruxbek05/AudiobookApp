using Application.Model;
using Application.Model.Review;

namespace Application.Service;

public interface IReviewService
{
    Task<ApiResult<ReviewCMResponce>> CreateReviewAsync(ReviewCM model);
    Task<ApiResult<ReviewRM>> GetByIdReviewAsync(Guid id);
    Task<ApiResult<IEnumerable<ReviewRM>>> GetAllReviewsAsync();
    Task<ApiResult<ReviewUMResponce>> UpdateReviewAsync(ReviewUM model);
    Task<ApiResult<bool>> DeleteReviewAsync(Guid id);
}
