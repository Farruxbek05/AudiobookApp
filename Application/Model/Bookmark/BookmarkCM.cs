namespace Application.Model.Bookmark;

public class BookmarkCM
{
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public int Chapter { get; set; }
    public TimeSpan AudioPosition { get; set; }
}

public class BookmarkCMResponse : BaseResponceModel { }
