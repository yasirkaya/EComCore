using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.DTOs.UserRoleDTO;

namespace EComCore.Domain.Services.Queries;

public interface IUserRoleQueryService
{
    Task<IEnumerable<UserRoleDetailsDto>> GetAllAsync();
    Task<UserRoleDetailsDto> GetByIdAsync(int id);
    Task<IEnumerable<UserRoleDetailsDto>> GetByRoleIdAsync(int roleId);
    Task<IEnumerable<UserRoleDetailsDto>> GetByUserIdAsync(int userId);
    Task<bool> IsUserInRoleAsync(int userId, int roleId);
}