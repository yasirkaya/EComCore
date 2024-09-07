namespace EComCore.Domain.DTOs.CategoryDTO;

public class CreateCategoryDto
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public DateTime CreatedAt { get; set; }
}