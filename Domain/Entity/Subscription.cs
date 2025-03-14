using Domain.Common;

namespace Domain.Entity;

public class Subscription : BaseEntity, IAuditedEntity
{
    public string PlanName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int DurationInDays { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}