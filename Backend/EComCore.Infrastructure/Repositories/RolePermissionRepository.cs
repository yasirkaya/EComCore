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

        public override async Task<IEnumerable<RolePermission>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.Role)
                .Include(x => x.Permission)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<RolePermission> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Role)
                .Include(x => x.Permission)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<RolePermission>> GetByPermissionIdAsync(int permissionId)
        {
            return await _dbSet
                .Include(x => x.Role)
                .Include(x => x.Permission)
                .Where(x => x.PermissionId == permissionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RolePermission>> GetByRoleIdAsync(int roleId)
        {
            return await _dbSet
                .Include(x => x.Role)
                .Include(x => x.Permission)
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