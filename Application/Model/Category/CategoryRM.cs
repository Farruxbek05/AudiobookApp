namespace Application.Model.Category;

public class CategoryRM : BaseResponceModel
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}