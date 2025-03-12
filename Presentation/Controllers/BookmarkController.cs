using Application.Model.Bookmark;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookmarkController : ControllerBase
{
    private readonly IBookmarkService _bookmarkService;
    public BookmarkController(IBookmarkService bookmarkService)
    {
        _bookmarkService = bookmarkService;
    }

    [HttpGet("GetLastPosition/{userId}/{bookId}")]
    public async Task<IActionResult> GetLastPosition(Guid userId, Guid bookId)
    {
        var res = await _bookmarkService.GetLastPositionAsync(userId, bookId);
        return res.IsSuccess ? Ok(res) : NotFound(res);
    }


    [HttpPost("SaveLastPosition")]
    public async Task<IActionResult> SaveLastPosition([FromBody] BookmarkUM bookmarkUM)
    {
        var res = await _bookmarkService.CreateOrUpdateBookmarkAsync(bookmarkUM);
        return res.IsSuccess ? Ok(res) : BadRequest(res);
    }
}