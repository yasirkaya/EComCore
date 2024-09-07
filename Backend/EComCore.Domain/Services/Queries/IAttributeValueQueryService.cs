using System.ComponentModel;
using EComCore.Domain.DTOs.AttributeValueDTO;

namespace EComCore.Domain.Services.Queries;

public interface IAttributeValueQueryService
{
    Task<IEnumerable<AttributeValueDto>> GetValuesByAttributeIdAsync(int attributeId);
    Task<AttributeValueDto> GetAttributeValueByIdAsync(int id);
    Task<IEnumerable<AttributeValueDto>> GetAllAsync();
}