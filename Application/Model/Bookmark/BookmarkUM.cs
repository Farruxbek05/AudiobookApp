namespace Application.Model.Bookmark;

public class BookmarkUM
{
    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
    public int Chapter { get; set; }
    public string AudioPosition { get; set; }
}

public class BookmarkUMResponse : BaseResponceModel { }
