using Application.Model;
using Application.Model.Bookmark;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Service.Impl;

public class BookmarkService : IBookmarkService
{
    private readonly IMapper _mapper;
    private readonly AudiobookDbContext _dbContext;

    public BookmarkService(IMapper mapper, AudiobookDbContext context)
    {
        _mapper = mapper;
        _dbContext = context;
    }

    public async Task<ApiResult<BookmarkUMResponse>> CreateOrUpdateBookmarkAsync(BookmarkUM model)
    {
        var bookmark = await _dbContext.Bookmarks
            .FirstOrDefaultAsync(b => b.UserId == model.UserId && b.BookId == model.BookId);

        if (bookmark == null)
        {
            bookmark = _mapper.Map<Bookmark>(model);
            bookmark.UpdatedOn = DateTime.UtcNow;
            await _dbContext.Bookmarks.AddAsync(bookmark);
        }
        else
        {
            _mapper.Map(model, bookmark);
            bookmark.UpdatedOn = DateTime.UtcNow;
            _dbContext.Entry(bookmark).State = EntityState.Modified;
        }

        await _dbContext.SaveChangesAsync();
        return ApiResult<BookmarkUMResponse>.Success(new BookmarkUMResponse { Id = bookmark.Id });
    }
    public async Task<ApiResult<BookmarkRM>> GetLastPositionAsync(Guid userId, Guid bookId)
    {
        var bookmark = await _dbContext.Bookmarks
            .AsNoTracking()
            .Where(b => b.UserId == userId && b.BookId == bookId)
            .OrderByDescending(b => b.UpdatedOn)
            .FirstOrDefaultAsync();

        if (bookmark == null)
        {
            return ApiResult<BookmarkRM>.Failure(new List<string> { "No bookmark found" });
        }

        return ApiResult<BookmarkRM>.Success(_mapper.Map<BookmarkRM>(bookmark));
    }


}
