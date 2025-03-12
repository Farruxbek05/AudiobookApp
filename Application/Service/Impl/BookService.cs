using Application.Model;
using Application.Model.Book;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Service.Impl;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly AudiobookDbContext _dbContext;
    private readonly IWebHostEnvironment _environment;

    public BookService(IMapper mapper, AudiobookDbContext context, IWebHostEnvironment environment)
    {
        _mapper = mapper;
        _dbContext = context;
        _environment = environment;
    }

    public async Task<ApiResult<BookCMResponse>> CreateBookAsync(BookCM model)
    {
        var book = _mapper.Map<Book>(model);
        book.CreatedOn = DateTime.UtcNow;

        string uploadsDirectory = Path.Combine(_environment.WebRootPath, "bookuploads");
        if (!Directory.Exists(uploadsDirectory))
        {
            Directory.CreateDirectory(uploadsDirectory);
        }

        if (model.PdfFile != null)
        {
            var pdfPath = Path.Combine(_environment.WebRootPath, "bookuploads", model.PdfFile.FileName);
            using var stream = new FileStream(pdfPath, FileMode.Create);
            await model.PdfFile.CopyToAsync(stream);
            book.PdfUrl = pdfPath;
        }

        if (model.AudioFile != null)
        {
            var audioPath = Path.Combine(_environment.WebRootPath, "bookuploads", model.AudioFile.FileName);
            using var stream = new FileStream(audioPath, FileMode.Create);
            await model.AudioFile.CopyToAsync(stream);
            book.AudioUrl = audioPath;
        }

        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();
        return ApiResult<BookCMResponse>.Success(new BookCMResponse { Id = book.Id });
    }

    public async Task<ApiResult<bool>> DeleteBookAsync(Guid id)
    {
        var book = _dbContext.Books.FirstOrDefault(t => t.Id == id);
        if (book == null)
        {
            return ApiResult<bool>.Failure(new List<string> { "Book not found" });
        }

        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();

        return ApiResult<bool>.Success(true);
    }

    public async Task<ApiResult<IEnumerable<BookRM>>> GetAllBooksAsync()
    {
        var books = await _dbContext.Books
                                     .AsNoTracking()
                                     .ProjectTo<BookRM>(_mapper.ConfigurationProvider)
                                     .ToListAsync();
        return ApiResult<IEnumerable<BookRM>>.Success(books);
    }

    public async Task<ApiResult<BookRM>> GetByIdBookAsync(Guid id)
    {
        var book = await _dbContext.Books
                                    .AsNoTracking()
                                    .ProjectTo<BookRM>(_mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync(c => c.Id == id);

        if (book == null)
        {
            return ApiResult<BookRM>.Failure(new List<string> { "Book not found" });
        }

        return ApiResult<BookRM>.Success(book);
    }

    public async Task<ApiResult<BookUMResponse>> UpdateBookAsync(BookUM model)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(s => s.Id == model.Id);

        if (book == null)
        {
            return ApiResult<BookUMResponse>.Failure(new List<string> { "Book not found" });
        }

        _mapper.Map(model, book);
        book.UpdatedOn = DateTime.UtcNow;
        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();

        return ApiResult<BookUMResponse>.Success(new BookUMResponse { Id = book.Id });
    }

    public async Task<ApiResult<byte[]>> GetFileAsync(string filePath)
    {
        var fullPath = Path.Combine(_environment.WebRootPath, filePath);
        if (!File.Exists(fullPath))
            return ApiResult<byte[]>.Failure(new List<string> { "File not found" });

        var fileBytes = await File.ReadAllBytesAsync(fullPath);
        return ApiResult<byte[]>.Success(fileBytes);
    }
    public async Task<FileContentResult> GetAudioFileAsync(Guid bookId)
    {
        var book = await _dbContext.Books.FindAsync(bookId);

        if (book == null || string.IsNullOrEmpty(book.AudioUrl))
            return null;


        if (!File.Exists(book.AudioUrl))
            return null;


        var contentType = "audio/mpeg";
        var extension = Path.GetExtension(book.AudioUrl).ToLowerInvariant();

        switch (extension)
        {
            case ".mp3":
                contentType = "audio/mpeg";
                break;
            case ".wav":
                contentType = "audio/wav";
                break;
            case ".ogg":
                contentType = "audio/ogg";
                break;

        }


        var fileBytes = await File.ReadAllBytesAsync(book.AudioUrl);
        return new FileContentResult(fileBytes, contentType)
        {
            FileDownloadName = Path.GetFileName(book.AudioUrl)
        };
    }

    public async Task<bool> AudioExistsAsync(Guid bookId)
    {
        var book = await _dbContext.Books.FindAsync(bookId);

        if (book == null || string.IsNullOrEmpty(book.AudioUrl))
            return false;

        return File.Exists(book.AudioUrl);
    }
    public async Task<FileContentResult> GetPdfFileAsync(Guid bookId)
    {
        var book = await _dbContext.Books.FindAsync(bookId);

        if (book == null || string.IsNullOrEmpty(book.PdfUrl))
            return null;


        if (!File.Exists(book.PdfUrl))
            return null;


        var fileBytes = await File.ReadAllBytesAsync(book.PdfUrl);
        return new FileContentResult(fileBytes, "application/pdf")
        {
            FileDownloadName = Path.GetFileName(book.PdfUrl)
        };
    }

    public async Task<bool> PdfExistsAsync(Guid bookId)
    {
        var book = await _dbContext.Books.FindAsync(bookId);

        if (book == null || string.IsNullOrEmpty(book.PdfUrl))
            return false;

        return File.Exists(book.PdfUrl);
    }
}



