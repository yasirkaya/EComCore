namespace EComCore.Domain.DTOs.ProductToAttributeDTO;

public class CreateProductToAttributeDto
{
    public int ProductId { get; set; }
    public int AttributeId { get; set; }
    public int AttributeValueId { get; set; }
}