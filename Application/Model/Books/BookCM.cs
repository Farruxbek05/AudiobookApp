using Microsoft.AspNetCore.Http;

namespace Application.Model.Books;

public class BookCM
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public IFormFile? PdfFile { get; set; }
    public IFormFile? AudioFile { get; set; }
}
public class BookCMResponse : BaseResponceModel { }
