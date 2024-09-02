namespace EComCore.Domain.Entities;

public class ProductToAttribute
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int AttributeId { get; set; }
    public CustomAttribute Attribute { get; set; }
    public int AttributeValueId { get; set; }
    public AttributeValue AttributeValue { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}