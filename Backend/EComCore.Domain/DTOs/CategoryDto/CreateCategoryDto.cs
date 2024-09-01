namespace EComCore.Domain.DTOs.CategoryDto;

public class CreateCategoryDto
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public DateTime CreatedAt { get; set; }
}