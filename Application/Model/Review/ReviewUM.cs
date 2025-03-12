namespace Application.Model.Review;

public class ReviewUM
{
    public Guid Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
}

public class ReviewUMResponce : BaseResponceModel { }