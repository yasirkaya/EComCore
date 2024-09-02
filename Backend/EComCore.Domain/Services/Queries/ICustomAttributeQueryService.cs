using EComCore.Domain.DTOs.AttributeDto;

namespace EComCore.Domain.Services.Queries;

public interface ICustomAttributeQueryService
{
    Task<IEnumerable<CustomAttributeDto>> GetAllAsync();
    Task<CustomAttributeDto> GetByIdAsync(int id);
}