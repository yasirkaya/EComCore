using EComCore.Domain.DTOs.ReviewDTO;

namespace EComCore.Domain.Services.Queries;

public interface IReviewQueryService
{
    Task<IEnumerable<ReviewDto>> GetAllAsync();
    Task<ReviewDto> GetByIdAsync(int id);
    Task<IEnumerable<ReviewDto>> GetByProductIdAsync(int productId);
    Task<IEnumerable<ReviewDto>> GetByUserIdAsync(int userId);
    Task<IEnumerable<ReviewDto>> GetPeddingReviewsAsync(string status);
}