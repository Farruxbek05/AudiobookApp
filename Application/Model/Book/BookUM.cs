namespace Application.Model.Book;

public class BookUM
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class BookUMResponse : BaseResponceModel { }