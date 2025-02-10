using EComCore.Domain.Entities;
using EComCore.Domain.Enums;

namespace EComCore.Domain.Repositories;

public interface IReviewRepository : IRepository<Review>
{
    Task<IEnumerable<Review>> GetByProductIdAsync(int productId);
    Task<IEnumerable<Review>> GetByUserIdAsync(int userId);
    Task<IEnumerable<Review>> GetByStatusAsync(ReviewStatus status);
}

