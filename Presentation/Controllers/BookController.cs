﻿using Application.Model.Books;
using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("GetAllBooks")]
    [Authorize(Policy = "AdminOrUser")]
    public async Task<IActionResult> GetAllBooks()
    {
        var res = await _bookService.GetAllBooksAsync();
        return Ok(res);
    }
    [Authorize(Policy = "AdminOrUser")]
    [HttpGet("GetBook/{id}")]
    public async Task<IActionResult> GetBook(Guid id)
    {
        var res = await _bookService.GetByIdBookAsync(id);
        return Ok(res);
    }
    [HttpGet("Search")]
    public async Task<IActionResult> Searche(string text)
    {
        var res = await _bookService.Name(text);
        return Ok(res);
    }
    [HttpPost("CreateBook")]
    public async Task<IActionResult> CreateBook([FromForm] BookCM bookCM)
    {
        var res = await _bookService.CreateBookAsync(bookCM);
        return Ok(res);
    }
    [Authorize(Policy = "RequireAdminRole")]
    [HttpPut("UpdateBook")]
    public async Task<IActionResult> UpdateBook(BookUM bookUM)
    {
        var res = await _bookService.UpdateBookAsync(bookUM);
        return Ok(res);
    }
    [Authorize(Policy = "RequireAdminRole")]
    [HttpDelete("DeleteBook")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        var res = await _bookService.DeleteBookAsync(id);
        return Ok(res);
    }
    [Authorize(Policy = "AdminOrUser")]
    [HttpGet("GetAudioFileAsync")]
    public async Task<IActionResult> GetAudio(Guid bookId)
    {
        var exists = await _bookService.AudioExistsAsync(bookId);
        if (!exists)
            return NotFound("Audio file not found for this book");

        var audioFile = await _bookService.GetAudioFileAsync(bookId);
        if (audioFile == null)
            return NotFound("Could not retrieve audio file");

        return audioFile;
    }
    [Authorize(Policy = "AdminOrUser")]
    [HttpGet("GetPdfFileAsync")]
    public async Task<IActionResult> GetPdf(Guid bookId)
    {
        var exists = await _bookService.PdfExistsAsync(bookId);
        if (!exists)
            return NotFound("PDF file not found for this book");

        var pdfFile = await _bookService.GetPdfFileAsync(bookId);
        if (pdfFile == null)
            return NotFound("Could not retrieve PDF file");

        return pdfFile;
    }

}

