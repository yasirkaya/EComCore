namespace EComCore.Domain.DTOs.ProductToAttributeDTO;

public class UpdateProductToAttributeDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int AttributeId { get; set; }
    public int AttributeValueId { get; set; }
}