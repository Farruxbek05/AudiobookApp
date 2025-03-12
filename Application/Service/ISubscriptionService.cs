using Application.Model;
using Application.Model.Subscription;

namespace Application.Service;

public interface ISubscriptionService
{
    Task<ApiResult<SubscriptionCMResponse>> CreateSubscriptionAsync(SubscriptionCM model);
    Task<ApiResult<SubscriptionRM>> GetByIdSubscriptionAsync(Guid id);
    Task<ApiResult<IEnumerable<SubscriptionRM>>> GetAllSubscriptionAsync();
    Task<ApiResult<SubscriptionUMResponse>> UpdateSubscriptionAsync(SubscriptionUM model);
    Task<ApiResult<bool>> DeleteSubscriptionAsync(Guid id);
}
