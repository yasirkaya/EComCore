using EComCore.Domain.DTOs;
using EComCore.Domain.Entities;

namespace EComCore.Domain.Services.Queries;

public interface IRoleQueryService
{
    Task<RoleDto> GetByNameAsync(string name);
    Task<RoleDto> GetByIdAsync(int id);
}