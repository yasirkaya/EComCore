using EComCore.Domain.Entities;

namespace EComCore.Domain.Services.Queries;

public interface IRolePermissionQueryService
{
    Task<IEnumerable<RolePermission>> GetAllAsync();
    Task<RolePermission> GetByIdAsync(int id);
    Task<IEnumerable<RolePermission>> GetByRoleIdAsync(int roleId);
    Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(int permissionId);
    Task<bool> IsExistAsync(int roleId, int permissionId);
}
