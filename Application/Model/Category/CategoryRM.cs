using Domain.Entity;

namespace Application.Model.Category;

public class CategoryRM : BaseResponceModel
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}