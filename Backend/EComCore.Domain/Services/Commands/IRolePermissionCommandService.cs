using EComCore.Domain.Entities;

namespace EComCore.Domain.Services.Commands;

public interface IRolePermissionCommandService
{
    Task AddAsync(RolePermission rolePermission);
    Task UpdateAsync(RolePermission rolePermission);
    Task DeleteAsync(int id);
}
