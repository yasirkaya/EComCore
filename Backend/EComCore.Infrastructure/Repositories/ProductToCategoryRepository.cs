using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Shared.RequestFeatures;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class ProductToCategoryRepository : Repository<ProductToCategory>, IProductToCategoryRepository
{
    private readonly EComCoreDbContext _context;
    public ProductToCategoryRepository(EComCoreDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task DeleteByProductIdAsync(IEnumerable<ProductToCategory> prodCats)
    {
        _context.ProductToCategories.RemoveRange(prodCats);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductToCategory>> GetByCategoryIdAsync(int categoryId, ProductToCategoryParameters productToCategoryParameters)
    {
        return await _context.ProductToCategories
            .Where(ptc => ptc.CategoryId == categoryId)
            .OrderBy(p => p.ProductId)
            .Skip((productToCategoryParameters.PageNumber - 1) * productToCategoryParameters.PageSize)
            .Take(productToCategoryParameters.PageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductToCategory>> GetByProductIdAsync(int productId)
    {
        return await _context.ProductToCategories
                         .Where(ptc => ptc.ProductId == productId)
                         .ToListAsync();
    }
}