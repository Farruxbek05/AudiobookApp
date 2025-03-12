namespace Application.Model.Subscription;

public class SubscriptionUM
{
    public Guid Id { get; set; }
    public string PlanName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int DurationInDays { get; set; }
}
public class SubscriptionUMResponse : BaseResponceModel { }
