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
            .Include(p => p.OrderItems)
            .Where(p => !p.IsDeleted)
            .OrderByDescending(p => p.OrderItems.Sum(oi => oi.Quantity))
            .Take(count)
            .ToListAsync();
    }
}