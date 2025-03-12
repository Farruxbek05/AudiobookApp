namespace Application.Model.Subscription;

public class SubscriptionCM
{
    public string PlanName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int DurationInDays { get; set; }
}

public class SubscriptionCMResponse : BaseResponceModel { }