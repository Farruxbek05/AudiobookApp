namespace Application.Model.Subscription;

public class SubscriptionRM : BaseResponceModel
{
    public string PlanName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int DurationInDays { get; set; }
}

