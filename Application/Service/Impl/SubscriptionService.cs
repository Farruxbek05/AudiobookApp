using Application.Model;
using Application.Model.Subscription;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Service.Impl;

public class SubscriptionService : ISubscriptionService
{
    private readonly IMapper _mapper;
    private readonly AudiobookDbContext _dbContext;

    public SubscriptionService(IMapper mapper, AudiobookDbContext context)
    {
        _mapper = mapper;
        _dbContext = context;
    }

    public async Task<ApiResult<SubscriptionCMResponse>> CreateSubscriptionAsync(SubscriptionCM model)
    {
        var subscription = _mapper.Map<Subscription>(model);
        subscription.CreatedOn = DateTime.UtcNow;
        _dbContext.Subscriptions.Add(subscription);
        await _dbContext.SaveChangesAsync();
        return ApiResult<SubscriptionCMResponse>.Success(new SubscriptionCMResponse { Id = subscription.Id });
    }

    public async Task<ApiResult<bool>> DeleteSubscriptionAsync(Guid id)
    {
        var subscription = _dbContext.Subscriptions.FirstOrDefault(t => t.Id == id);
        if (subscription == null)
            return ApiResult<bool>.Failure(new List<string> { "Subscription not found" });

        _dbContext.Subscriptions.Remove(subscription);
        await _dbContext.SaveChangesAsync();
        return ApiResult<bool>.Success(true);
    }

    public async Task<ApiResult<IEnumerable<SubscriptionRM>>> GetAllSubscriptionAsync()
    {
        var subscriptions = await _dbContext.Subscriptions.AsNoTracking().ProjectTo<SubscriptionRM>(_mapper.ConfigurationProvider).ToListAsync();
        return ApiResult<IEnumerable<SubscriptionRM>>.Success(subscriptions);
    }

    public async Task<ApiResult<SubscriptionRM>> GetByIdSubscriptionAsync(Guid id)
    {
        var subscription = await _dbContext.Subscriptions.AsNoTracking().ProjectTo<SubscriptionRM>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);
        if (subscription == null)
            return ApiResult<SubscriptionRM>.Failure(new List<string> { "Subscription not found" });

        return ApiResult<SubscriptionRM>.Success(subscription);
    }

    public async Task<ApiResult<SubscriptionUMResponse>> UpdateSubscriptionAsync(SubscriptionUM model)
    {
        var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(s => s.Id == model.Id);
        if (subscription == null)
            return ApiResult<SubscriptionUMResponse>.Failure(new List<string> { "Subscription not found" });

        _mapper.Map(model, subscription);
        subscription.UpdatedOn = DateTime.Now;
        _dbContext.Subscriptions.Update(subscription);
        await _dbContext.SaveChangesAsync();
        return ApiResult<SubscriptionUMResponse>.Success(new SubscriptionUMResponse { Id = subscription.Id });
    }
}
