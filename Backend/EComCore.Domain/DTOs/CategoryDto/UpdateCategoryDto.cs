namespace EComCore.Domain.DTOs.CategoryDto;

public class UpdateCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public DateTime UpdatedAt { get; set; }
}