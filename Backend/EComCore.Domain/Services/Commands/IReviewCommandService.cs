using EComCore.Domain.DTOs.ReviewDTO;

namespace EComCore.Domain.Services.Commands;

public interface IReviewCommandService
{
    Task<int> CreateAsync(CreateReviewDto reviewDto);
    Task<bool> UpdateAsync(UpdateReviewDto reviewDto);
    Task<bool> DeleteAsync(int id);
}