namespace EComCore.Domain.DTOs.CategoryDTO;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
}