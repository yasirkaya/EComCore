namespace EComCore.Domain.Entities;

public class CustomAttribute : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<AttributeValue> AttributeValues { get; set; }
}