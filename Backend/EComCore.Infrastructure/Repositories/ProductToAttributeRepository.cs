using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class ProductToAttributeRepository : Repository<ProductToAttribute>, IProductToAttributeRepository
{
    private readonly EComCoreDbContext _context;
    public ProductToAttributeRepository(EComCoreDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task AddRangeAsync(IEnumerable<ProductToAttribute> productToAttributes)
    {
        await _context.ProductToAttributes.AddRangeAsync(productToAttributes);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<ProductToAttribute> productToAttributes)
    {
        _context.ProductToAttributes.RemoveRange(productToAttributes);
        await _context.SaveChangesAsync();
    }

    public async Task<ProductToAttribute> FindByProductIdAndAttributeIdAsync(int productId, int attributeId)
    {
        return await _context.ProductToAttributes
                            .Where(x => x.ProductId == productId && x.AttributeId == attributeId)
                            .Include(x => x.Attribute)
                            .Include(x => x.Product)
                            .FirstOrDefaultAsync();
    }

    public override async Task<IEnumerable<ProductToAttribute>> GetAllAsync()
    {
        return await _context.ProductToAttributes
                                .Include(a => a.Attribute)
                                .Include(av => av.AttributeValue)
                                .ToListAsync();
    }

    public async Task<IEnumerable<ProductToAttribute>> GetAttributesByProductIdAsync(int productId)
    {
        return await _context.ProductToAttributes
                                .Where(x => x.ProductId == productId)
                                .Include(x => x.Attribute)
                                .Include(x => x.AttributeValue)
                                .ToListAsync();
    }

    public override async Task<ProductToAttribute> GetByIdAsync(int id)
    {
        return await _context.ProductToAttributes
                                .Where(x => x.Id == id)
                                .Include(a => a.Attribute)
                                .Include(av => av.AttributeValue)
                                .SingleOrDefaultAsync();
    }


}