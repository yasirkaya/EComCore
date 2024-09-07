using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;

namespace EComCore.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly EComCoreDbContext _context;
    public ProductRepository(EComCoreDbContext context) : base(context)
    {
        _context = context;
    }


}