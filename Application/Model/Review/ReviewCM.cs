namespace Application.Model.Review;

public class ReviewCM
{
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    public Guid UserId { get; set; }
    public Guid GameId { get; set; }
}

public class ReviewCMResponce : BaseResponceModel { }