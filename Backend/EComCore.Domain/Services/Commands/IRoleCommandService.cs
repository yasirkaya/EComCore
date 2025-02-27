using EComCore.Domain.DTOs;

namespace EComCore.Domain.Services.Commands;

public interface IRoleCommandService
{
    Task CreateAsync(CreateRoleDto roleDto);
    Task UpdateAsync(UpdateRoleDto roleDto);
    Task DeleteAsync(int id);

}