using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.DTOs.UserRoleDTO;

namespace EComCore.Domain.Services.Queries;

public interface IUserRoleQueryService
{
    Task<IEnumerable<UserRoleDetailsDto>> GetUserRolesAsync(int userId);
    Task<IEnumerable<UserDetailsDto>> GetUsersInRoleAsync(string roleName);
    Task<bool> IsUserInRoleAsync(int userId, string roleName);
}