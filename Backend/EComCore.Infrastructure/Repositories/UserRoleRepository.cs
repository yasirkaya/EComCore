using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(EComCoreDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<UserRole>> GetAllAsync()
    {
        return await _dbSet
            .Include(x => x.Role)
            .Include(x => x.User)
            .AsNoTracking()
            .ToListAsync();
    }

    public override async Task<UserRole> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(x => x.Role)
            .Include(x => x.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<UserRole>> GetByRoleIdAsync(int roleId)
    {
        return await _context.UserRoles
            .Where(x => x.RoleId == roleId)
            .Include(x => x.Role)
            .Include(x => x.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserRole>> GetByRoleNameAsync(string roleName)
    {
        return await _context.UserRoles
            .Where(x => x.Role.Name == roleName)
            .Include(x => x.Role)
            .Include(x => x.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserRole>> GetByUserIdAsync(int userId)
    {
        return await _context.UserRoles
            .Where(x => x.UserId == userId)
            .Include(x => x.Role)
            .Include(x => x.User)
            .ToListAsync();
    }

    public async Task<bool> IsExistAsync(int userId, int roleId)
    {
        return await _context.UserRoles
            .AsNoTracking()
            .AnyAsync(x => x.UserId == userId && x.RoleId == roleId);
    }

    public async Task<IEnumerable<string>> GetUserRolesAsync(int id)
    {
        return await _context.UserRoles
        .Where(x => x.UserId == id)
        .Select(x => x.Role.Name)
        .ToListAsync();

    }

    public async Task<UserRole> GetByUserIdAndRoleIdAsync(int userId, int roleId)
    {
        return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
    }
}