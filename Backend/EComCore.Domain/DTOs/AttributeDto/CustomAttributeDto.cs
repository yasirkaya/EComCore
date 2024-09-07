using EComCore.Domain.DTOs.AttributeValueDTO;
using EComCore.Domain.Entities;

namespace EComCore.Domain.DTOs.AttributeDTO;

public class CustomAttributeDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<AttributeValueDto> AttributeValues { get; set; } = new List<AttributeValueDto>();
}