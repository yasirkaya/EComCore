using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories
{
    public interface IRolePermissionRepository : IRepository<RolePermission>
    {
        Task<IEnumerable<RolePermission>> GetByRoleIdAsync(int roleId);
        Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(int permissionId);
        Task<bool> IsExistAsync(int roleId, int permissionId);
    }
}