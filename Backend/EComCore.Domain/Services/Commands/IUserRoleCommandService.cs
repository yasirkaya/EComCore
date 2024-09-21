using EComCore.Domain.DTOs.UserRoleDTO;

namespace EComCore.Domain.Services.Commands;

public interface IUserRoleCommandService
{
    Task<int> AddAsync(CreateUserRoleDto dto);
    Task DeleteAsync(DeleteUserRoleDto dto);
}