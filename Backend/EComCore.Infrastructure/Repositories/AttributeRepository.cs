using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;

namespace EComCore.Infrastructure.Repositories;

public class AttributeRepository : Repository<CustomAttribute>, IAttributeRepository
{
    public AttributeRepository(EComCoreDbContext context) : base(context)
    {
    }
}