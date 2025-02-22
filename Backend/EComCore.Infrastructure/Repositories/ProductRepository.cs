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

}