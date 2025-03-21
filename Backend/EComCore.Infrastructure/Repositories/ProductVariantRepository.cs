using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class ProductVariantRepository : Repository<ProductVariant>, IProductVariantRepository
{
    public ProductVariantRepository(EComCoreDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductVariant>> GetByProductIdAsync(int productId)
    {
        return await _context.ProductVariants
            .Include(pv => pv.ProductVariantAttributes)
            .Where(pv => pv.ProductId == productId)
            .ToListAsync();
    }

    public async Task<ProductVariant> GetBySkuAsync(string sku)
    {
        return await _context.ProductVariants
            .Include(pv => pv.ProductVariantAttributes)
            .FirstOrDefaultAsync(pv => pv.SKU == sku);
    }

    public async Task<IEnumerable<ProductVariant>> GetByAttributeValueAsync(int attributeValueId)
    {
        return await _context.ProductVariantAttributes
            .Include(pva => pva.ProductVariant)
            .Where(pva => pva.AttributeValueId == attributeValueId)
            .Select(pva => pva.ProductVariant)
            .Distinct()
            .ToListAsync();
    }
}
