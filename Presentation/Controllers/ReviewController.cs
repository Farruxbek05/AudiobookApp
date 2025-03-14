using Application.Model.Review;
using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("GetAllReviews")]
    public async Task<IActionResult> GetAllReviews()
    {
        var res = await _reviewService.GetAllReviewsAsync();
        return Ok(res);
    }

    [HttpGet("GetReview/{id}")]
    public async Task<IActionResult> GetReview(Guid id)
    {
        var res = await _reviewService.GetByIdReviewAsync(id);
        return Ok(res);
    }

    [HttpPost("CreateReview")]
    public async Task<IActionResult> CreateReview(ReviewCM reviewCM)
    {
        var res = await _reviewService.CreateReviewAsync(reviewCM);
        return Ok(res);
    }

    [HttpPut("UpdateReview")]
    public async Task<IActionResult> UpdateReview(ReviewUM reviewUM)
    {
        var res = await _reviewService.UpdateReviewAsync(reviewUM);
        return Ok(res);
    }

    [HttpDelete("DeleteReview")]
    public async Task<IActionResult> DeleteReview(Guid id)
    {
        var res = await _reviewService.DeleteReviewAsync(id);
        return Ok(res);
    }
}

