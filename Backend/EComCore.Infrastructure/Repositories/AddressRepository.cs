using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(EComCoreDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Address>> GetByUserIdAsync(int userId)
    {
        return await _dbSet.Where(x => x.UserId == userId).ToListAsync();
    }
}