using Application.Model.Subscription;
using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet("GetAllSubscriptions")]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var res = await _subscriptionService.GetAllSubscriptionAsync();
        return Ok(res);
    }

    [HttpGet("GetSubscription/{id}")]
    public async Task<IActionResult> GetSubscription(Guid id)
    {
        var res = await _subscriptionService.GetByIdSubscriptionAsync(id);
        return Ok(res);
    }

    [HttpPost("CreateSubscription")]
    public async Task<IActionResult> CreateSubscription(SubscriptionCM subscriptionCM)
    {
        var res = await _subscriptionService.CreateSubscriptionAsync(subscriptionCM);
        return Ok(res);
    }

    [HttpPut("UpdateSubscription")]
    public async Task<IActionResult> UpdateSubscription(SubscriptionUM subscriptionUM)
    {
        var res = await _subscriptionService.UpdateSubscriptionAsync(subscriptionUM);
        return Ok(res);
    }

    [HttpDelete("DeleteSubscription")]
    public async Task<IActionResult> DeleteSubscription(Guid id)
    {
        var res = await _subscriptionService.DeleteSubscriptionAsync(id);
        return Ok(res);
    }
}
