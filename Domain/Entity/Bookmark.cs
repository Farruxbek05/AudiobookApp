using Domain.Common;

namespace Domain.Entity;

public class Bookmark : BaseEntity, IAuditedEntity
{
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; } = null!;
    public int Chapter { get; set; }
    public TimeSpan AudioPosition { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}