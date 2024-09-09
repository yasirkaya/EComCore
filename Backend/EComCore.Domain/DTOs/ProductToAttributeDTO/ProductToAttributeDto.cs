namespace EComCore.Domain.DTOs.ProductToAttributeDTO;

public class ProductToAttributeDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int AttributeId { get; set; }
    public string AttributeName { get; set; }
    public int AttributeValueId { get; set; }
    public string AttributeValue { get; set; }
}