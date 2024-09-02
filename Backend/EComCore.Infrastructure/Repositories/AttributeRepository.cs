using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;

namespace EComCore.Infrastructure.Repositories;

public class AttributeRepository : Repository<CustomAttribute>, IAttributeRepository
{
    private readonly EComCoreDbContext _context;
    public AttributeRepository(EComCoreDbContext context) : base(context)
    {
        _context = context;
    }
}