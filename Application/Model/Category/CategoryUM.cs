namespace Application.Model.Category;

public class CategoryUM
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class CategoryUMResponse : BaseResponceModel { }
