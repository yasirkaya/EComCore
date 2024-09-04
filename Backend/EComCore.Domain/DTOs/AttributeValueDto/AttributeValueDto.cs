using EComCore.Domain.Entities;

namespace EComCore.Domain.DTOs.AttributeValueDto;

public class AttributeValueDto
{
    public int Id { get; set; }
    public int AttributeId { get; set; }
    public CustomAttribute Attribute { get; set; }
    public string Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}