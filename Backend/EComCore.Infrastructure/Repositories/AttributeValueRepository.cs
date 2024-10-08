using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class AttributeValueRepository : Repository<AttributeValue>, IAttributeValueRepository
{
    private readonly EComCoreDbContext _context;
    public AttributeValueRepository(EComCoreDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AttributeValue>> GetValuesByAttributeIdAsync(int attributeId)
    {
        return await _context.AttributeValues
                                .Where(x => x.AttributeId == attributeId)
                                .Include(x => x.Attribute)
                                .ToListAsync();
    }

    public override async Task<IEnumerable<AttributeValue>> GetAllAsync()
    {
        return await _context.AttributeValues
                                .Include(x => x.Attribute)
                                .ToListAsync();
    }
    public override async Task<AttributeValue> GetByIdAsync(int id)
    {
        return await _context.AttributeValues
                                    .Where(x => x.Id == id)
                                    .Include(x => x.Attribute)
                                    .FirstOrDefaultAsync();
    }

    public async Task RemoveRangeAsync(IEnumerable<AttributeValue> attributeValues)
    {
        _context.RemoveRange(attributeValues);
        await _context.SaveChangesAsync();
    }
}