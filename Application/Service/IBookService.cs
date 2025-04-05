using Application.Model;
using Application.Model.Books;
using Microsoft.AspNetCore.Mvc;

namespace Application.Service;

public interface IBookService
{
    Task<ApiResult<BookCMResponse>> CreateBookAsync(BookCM model);
    Task<ApiResult<BookRM>> GetByIdBookAsync(Guid id);
    Task<ApiResult<BookRM>> Name(string text);
    Task<ApiResult<IEnumerable<BookRM>>> GetAllBooksAsync();
    Task<ApiResult<BookUMResponse>> UpdateBookAsync(BookUM model);
    Task<ApiResult<bool>> DeleteBookAsync(Guid id);
    Task<ApiResult<byte[]>> GetFileAsync(string filePath);
    Task<FileContentResult> GetAudioFileAsync(Guid bookId);
    Task<bool> AudioExistsAsync(Guid bookId);
    Task<FileContentResult> GetPdfFileAsync(Guid bookId);
    Task<bool> PdfExistsAsync(Guid bookId);
}

