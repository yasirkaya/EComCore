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

    public override async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.Where(e => !e.IsDeleted).FirstOrDefaultAsync();
    }

}