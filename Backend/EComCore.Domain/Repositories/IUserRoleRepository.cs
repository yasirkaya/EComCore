using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IUserRoleRepository : IRepository<UserRole>
{
    Task<IEnumerable<UserRole>> GetByUserIdAsync(int userId);
    Task<IEnumerable<UserRole>> GetByRoleIdAsync(int roleId);
    Task<IEnumerable<UserRole>> GetByRoleNameAsync(string roleName);
    Task<bool> IsExistAsync(int userId, int roleId);
    Task<IEnumerable<string>> GetUserRolesAsync(int id);
}