using EComCore.Domain.Entities;

namespace EComCore.Domain.DTOs.AttributeValueDTO;

public class AttributeValueDto
{
    public int Id { get; set; }
    public string Value { get; set; }
    public int AttributeId { get; set; }
    public string AttributeName { get; set; }
}