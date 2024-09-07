using EComCore.Domain.DTOs.AttributeValueDTO;

namespace EComCore.Domain.Services.Commands;

public interface IAttributeValueCommandService
{
    Task<int> AddAsync(CreateAttributeValueDto dto);
    Task UpdateAsync(UpdateAttributeValueDto dto);
    Task DeleteAsync(DeleteAttributeValueDto dto);
    Task DeleteByAttributeIdAsync(int attributeId);
}