namespace Application.Model.Books;

public class BookRM : BaseResponceModel
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string? PdfUrl { get; set; }
    public string? AudioUrl { get; set; }
}
