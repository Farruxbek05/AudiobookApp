using Domain.Common;

namespace Domain.Entity;

public class Book : BaseEntity, IAuditedEntity
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    public string? PdfUrl { get; set; }
    public string? AudioUrl { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
  
}
