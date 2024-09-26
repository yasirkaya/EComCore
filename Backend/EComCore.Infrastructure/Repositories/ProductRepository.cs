using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Shared.RequestFeatures;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly EComCoreDbContext _context;
    public ProductRepository(EComCoreDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync(ProductParameters productParameters)
    {
        return await _context.Products
            .Where(p => !p.IsDeleted)
            .OrderBy(p => p.Name)
            .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
            .Take(productParameters.PageSize)
            .ToListAsync();
    }

    public override async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.Where(e => !e.IsDeleted).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetAllwithDeletedAsync(ProductParameters productParameters)
    {
        return await _context.Products
            .OrderBy(p => p.Name)
            .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
            .Take(productParameters.PageSize)
            .ToListAsync();
    }

}