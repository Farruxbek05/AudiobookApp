namespace Application.Model.Review;

public class ReviewRM : BaseResponceModel
{
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    public Guid UserId { get; set; }
    public Guid GameId { get; set; }
}
