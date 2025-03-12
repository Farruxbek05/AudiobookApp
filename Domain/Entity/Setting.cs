using Domain.Common;

namespace Domain.Entity;

public class Setting : BaseEntity, IAuditedEntity
{
    public Guid UserId { get; set; }
    public bool NotificationsEnabled { get; set; }
    public string Language { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
