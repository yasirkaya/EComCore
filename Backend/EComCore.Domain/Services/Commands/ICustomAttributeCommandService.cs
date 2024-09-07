using EComCore.Domain.DTOs.AttributeDTO;

namespace EComCore.Domain.Services.Commands;

public interface ICustomAttributeCommandService
{
    Task<int> AddAsync(CreateAttributeDto dto);
    Task UpdateAsync(UpdateAttributeDto dto);
    Task DeleteAsync(DeleteAttributeDto dto);
}