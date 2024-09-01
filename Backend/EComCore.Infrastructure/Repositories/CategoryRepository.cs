using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly EComCoreDbContext _context;
    public CategoryRepository(EComCoreDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetSubcategoriesAsync(int parentId)
    {
        return await _context.Categories.Where(c => c.ParentId == parentId).ToListAsync();
    }
}