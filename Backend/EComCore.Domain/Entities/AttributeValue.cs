namespace EComCore.Domain.Entities;

public class AttributeValue
{
    public int Id { get; set; }
    public int AttributeId { get; set; }
    public Attribute Attribute { get; set; }
    public string Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}