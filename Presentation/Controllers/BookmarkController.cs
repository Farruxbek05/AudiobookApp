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
        if (userId == Guid.Empty || bookId == Guid.Empty)
            return BadRequest(new { message = "Invalid userId or bookId." });

        var res = await _bookmarkService.GetLastPositionAsync(userId, bookId);

        if (res == null)
            return NotFound(new { message = "No bookmark found for the given user and book." });

        return res.IsSuccess ? Ok(res) : BadRequest(res);
    }



    [HttpPost("SaveLastPosition")]
    public async Task<IActionResult> SaveLastPosition([FromBody] BookmarkUM bookmarkUM)
    {
        if (bookmarkUM == null)
            return BadRequest(new { message = "Invalid request data." });

        try
        {
            TimeSpan audioTime = TimeSpan.Parse(bookmarkUM.AudioPosition);
            bookmarkUM.AudioPosition = audioTime.ToString();
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Invalid audioPosition format. Use HH:mm:ss format." });
        }

        var res = await _bookmarkService.CreateOrUpdateBookmarkAsync(bookmarkUM);

        if (res == null)
            return StatusCode(500, new { message = "Internal server error." });

        return res.Succeeded ? Ok(res) : BadRequest(res);
    }
}
