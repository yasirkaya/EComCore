using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class ProductVariantAttributeRepository : Repository<ProductVariantAttribute>, IProductVariantAttributeRepository
{
    public ProductVariantAttributeRepository(EComCoreDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductVariantAttribute>> GetByProductVariantIdAsync(int productVariantId)
    {
        return await _context.ProductVariantAttributes
            .Include(pva => pva.Attribute)
            .Include(pva => pva.AttributeValue)
            .Where(pva => pva.ProductVariantId == productVariantId)
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductVariantAttribute>> GetByAttributeIdAsync(int attributeId)
    {
        return await _context.ProductVariantAttributes
            .Include(pva => pva.ProductVariant)
            .Include(pva => pva.AttributeValue)
            .Where(pva => pva.AttributeId == attributeId)
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductVariantAttribute>> GetByAttributeValueIdAsync(int attributeValueId)
    {
        return await _context.ProductVariantAttributes
            .Include(pva => pva.ProductVariant)
            .Include(pva => pva.Attribute)
            .Where(pva => pva.AttributeValueId == attributeValueId)
            .ToListAsync();
    }
}
