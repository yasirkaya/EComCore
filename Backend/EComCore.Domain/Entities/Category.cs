namespace EComCore.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public Category Parent { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<ProductToCategory> ProductToCategories { get; set; } = new List<ProductToCategory>();
    public ICollection<Category> SubCategories { get; set; } = new List<Category>();
}