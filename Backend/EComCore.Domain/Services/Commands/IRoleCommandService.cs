using EComCore.Domain.DTOs;

namespace EComCore.Domain.Services.Commands;

public interface IRoleCommandService
{
    Task<RoleDto> CreateAsync(RoleDto roleDto);
    Task<RoleDto> UpdateAsync(RoleDto roleDto);
    Task DeleteAsync(int id);

}