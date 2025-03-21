using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Shared.RequestFeatures;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(EComCoreDbContext context) : base(context)
    {
    }

    public override async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products
            .Where(e => !e.IsDeleted && e.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetAllwithCategoriesAsync()
    {
        return await _context.Products
            .Include(p => p.ProductToCategories)
            .Where(e => !e.IsDeleted)
            .ToListAsync();
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await _context.Products.CountAsync(p => !p.IsDeleted);
    }

    public async Task<int> GetLowStockProductsCountAsync()
    {
        return await _context.Products.CountAsync(p => !p.IsDeleted && p.StockQuantity <= 10);
    }

    public async Task<IEnumerable<Product>> GetTopSellingProductsAsync(int count)
    {
        return await _context.Products
            .Include(p => p.ProductVariants)
                .ThenInclude(pv => pv.OrderItems)
            .Where(p => !p.IsDeleted)
            .OrderByDescending(p => p.ProductVariants.Sum(pv => pv.OrderItems.Sum(oi => oi.Quantity)))
            .Take(count)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
    {
        return await _context.ProductToCategories
            .Include(ptc => ptc.Product)
                .ThenInclude(p => p.ProductVariants)
            .Where(ptc => ptc.CategoryId == categoryId)
            .Select(ptc => ptc.Product)
            .ToListAsync();
    }

    public async Task<Product> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Products
            .Include(p => p.ProductToCategories)
                .ThenInclude(ptc => ptc.Category)
            .Include(p => p.ProductVariants)
                .ThenInclude(pv => pv.ProductVariantAttributes)
            .Include(p => p.Reviews)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetByAttributeValueIdAsync(int attributeValueId)
    {
        return await _context.ProductVariantAttributes
            .Include(pva => pva.ProductVariant)
                .ThenInclude(pv => pv.Product)
            .Where(pva => pva.AttributeValueId == attributeValueId)
            .Select(pva => pva.ProductVariant.Product)
            .Distinct()
            .ToListAsync();
    }
}