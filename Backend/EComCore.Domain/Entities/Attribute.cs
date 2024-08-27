namespace EComCore.Domain.Entities;

public class Attribute
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<AttributeValue> AttributeValues { get; set; }
}