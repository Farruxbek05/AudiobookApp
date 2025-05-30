﻿namespace Application.Model.Books;

public class BookUM
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
}

public class BookUMResponse : BaseResponceModel { }