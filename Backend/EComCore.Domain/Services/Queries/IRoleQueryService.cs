using EComCore.Domain.DTOs;
using EComCore.Domain.Entities;

namespace EComCore.Domain.Services.Queries;

public interface IRoleQueryService
{
    Task<IEnumerable<RoleDto>> GetAllAsync();
    Task<RoleDto> GetByNameAsync(string name);
    Task<RoleDto> GetByIdAsync(int id);
}