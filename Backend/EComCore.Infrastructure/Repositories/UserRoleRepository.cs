using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    private readonly EComCoreDbContext _context;
    public UserRoleRepository(EComCoreDbContext context) : base(context)
    {
        _context = context;
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

}