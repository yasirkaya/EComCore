namespace EComCore.Domain.DTOs.AttributeValueDTO;

public class UpdateAttributeValueDto
{
    public int Id { get; set; }
    public int AttributeId { get; set; }
    public string? Value { get; set; }
}