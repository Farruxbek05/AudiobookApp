namespace Application.Model.Bookmark;

public class BookmarkRM : BaseResponceModel
{
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public int Chapter { get; set; }
    public TimeSpan AudioPosition { get; set; }
}
