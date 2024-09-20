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

    public async Task<Role> GetByNameAsync(string name)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
    }
}