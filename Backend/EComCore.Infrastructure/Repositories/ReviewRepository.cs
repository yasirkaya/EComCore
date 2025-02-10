using EComCore.Domain.Entities;
using EComCore.Domain.Enums;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComCore.Infrastructure.Repositories;

public class ReviewRepository : Repository<Review>, IReviewRepository
{

    public ReviewRepository(EComCoreDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Review>> GetAllAsync()
    {
        return await _dbSet
            .Include(r => r.User)
            .Include(r => r.Product)
            .AsNoTracking()
            .ToListAsync();
    }
    public override async Task<Review> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(r => r.User)
            .Include(r => r.Product)
            .Where(r => r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Review>> GetByProductIdAsync(int productId)
    {
        return await _dbSet
            .Include(r => r.User)
            .Where(r => r.ProductId == productId && !r.IsDeleted && r.Status == ReviewStatus.Approved)
            .OrderByDescending(r => r.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetByStatusAsync(ReviewStatus status)
    {
        return await _dbSet
        .Where(r => r.Status == status)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetByUserIdAsync(int userId)
    {
        return await _dbSet
            .Include(r => r.Product)
            .Where(r => r.UserId == userId && !r.IsDeleted && r.Status == ReviewStatus.Approved)
            .OrderByDescending(r => r.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

}

