using AutoMapper;
using EComCore.Domain.DTOs.ReviewDTO;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

public class ReviewQueryService : IReviewQueryService
{
    private readonly IReviewRepository _repository;
    private readonly IMapper _mapper;

    public ReviewQueryService(IReviewRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReviewDto>> GetAllAsync()
    {
        var reviews = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
    }

    public async Task<ReviewDto> GetByIdAsync(int id)
    {
        var review = await _repository.GetByIdAsync(id);
        await review.EnsureNotNullAsync(id: id);
        return _mapper.Map<ReviewDto>(review);
    }

    public async Task<IEnumerable<ReviewDto>> GetByProductIdAsync(int productId)
    {
        var reviews = await _repository.GetByProductIdAsync(productId);
        return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
    }

    public async Task<IEnumerable<ReviewDto>> GetByUserIdAsync(int userId)
    {
        var reviews = await _repository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
    }

    public async Task<IEnumerable<ReviewDto>> GetPeddingReviewsAsync(string status)
    {
        var reviews = await _repository.GetByStatusAsync(status);
        return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
    }
}