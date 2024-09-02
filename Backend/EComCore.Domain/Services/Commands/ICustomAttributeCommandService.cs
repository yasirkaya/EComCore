using EComCore.Domain.DTOs.AttributeDto;

namespace EComCore.Domain.Services.Commands;

public interface ICustomAttributeCommandService
{
    Task<int> AddAsync(CreateAttribureDto dto);
    Task UpdateAsync(UpdateAttribureDto dto);
    Task DeleteAsync(DeleteAttribureDto dto);
}