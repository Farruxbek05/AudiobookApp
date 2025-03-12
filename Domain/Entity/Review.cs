using Domain.Common;

namespace Domain.Entity;

public class Review : BaseEntity, IAuditedEntity
{
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }

    public Guid UserId { get; set; }
    public Guid GameId { get; set; }

    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}


