using EComCore.Domain.DTOs;

namespace EComCore.Domain.Services.Queries;

public interface IRolePermissionQueryService
{
    Task<IEnumerable<RolePermissionDto>> GetAllAsync();
    Task<RolePermissionDto> GetByIdAsync(int id);
    Task<IEnumerable<RolePermissionDto>> GetByRoleIdAsync(int roleId);
    Task<IEnumerable<RolePermissionDto>> GetByPermissionIdAsync(int permissionId);
    Task<bool> IsExistAsync(int roleId, int permissionId);
}
