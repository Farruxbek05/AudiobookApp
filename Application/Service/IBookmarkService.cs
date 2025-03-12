using Application.Model;
using Application.Model.Bookmark;

namespace Application.Service;

public interface IBookmarkService
{
    Task<ApiResult<BookmarkUMResponse>> CreateOrUpdateBookmarkAsync(BookmarkUM model);
    Task<ApiResult<BookmarkRM>> GetLastPositionAsync(Guid userId, Guid bookId);
}
