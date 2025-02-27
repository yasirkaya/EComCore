using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    private readonly EComCoreDbContext _context;
    public RoleRepository(EComCoreDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _dbSet
        .Include(r => r.RolePermissions)
        .ThenInclude(rp => rp.Permission)
        .ToListAsync();
    }

    public override async Task<Role> GetByIdAsync(int id)
    {
        return await _dbSet
        .Include(r => r.RolePermissions)
        .ThenInclude(rp => rp.Permission)
        .FirstOrDefaultAsync(r => r.Id == id);
    }
    public async Task<Role> GetByNameAsync(string name)
    {
        return await _dbSet
        .Include(r => r.RolePermissions)
        .ThenInclude(rp => rp.Permission)
        .FirstOrDefaultAsync(r => r.Name == name);
    }
}