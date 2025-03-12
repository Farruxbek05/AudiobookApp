namespace Application.Model.Bookmark;

public class BookmarkUM
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
    public int Chapter { get; set; }
    public TimeSpan AudioPosition { get; set; }
}

public class BookmarkUMResponse : BaseResponceModel { }
