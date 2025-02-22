using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using EComCore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EComCore.ınfrastructure.Repositories
{
    public class RolePermissionRepository : Repository<RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(EComCoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(int permissionId)
        {
            return await _context.RolePermissions
                .Where(x => x.PermissionId == permissionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RolePermission>> GetByRoleIdAsync(int roleId)
        {
            return await _context.RolePermissions
                .Where(x => x.RoleId == roleId)
                .ToListAsync();
        }

        public async Task<bool> IsExistAsync(int roleId, int permissionId)
        {
            return await _context.RolePermissions
                .AnyAsync(x => x.RoleId == roleId && x.PermissionId == permissionId);
        }
    }
}