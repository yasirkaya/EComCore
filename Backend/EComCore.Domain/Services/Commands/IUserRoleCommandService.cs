using EComCore.Domain.DTOs.UserRoleDTO;

namespace EComCore.Domain.Services.Commands;

public interface IUserRoleCommandService
{
    Task<int> AddAsync(CreateUserRoleDto dto);
    Task UpdateAsync(UpdateUserRoleDto dto);
    Task DeleteAsync(DeleteUserRoleDto dto);
}