namespace EComCore.Domain.DTOs.CategoryDto;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
}