using AutoMapper;
using EComCore.Domain.DTOs.ReviewDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;
using EComCore.Domain.Services.Shared;

namespace EComCore.Application.Services.Commands;
public class ReviewCommandService : IReviewCommandService
{
    private readonly IReviewRepository _repository;
    private readonly IReviewAnalysisService _reviewAnalysisService;
    private readonly IMapper _mapper;

    public ReviewCommandService(IReviewRepository repository, IMapper mapper, IReviewAnalysisService reviewAnalysisService)
    {
        _repository = repository;
        _mapper = mapper;
        _reviewAnalysisService = reviewAnalysisService;
    }

    public async Task<int> CreateAsync(CreateReviewDto dto)
    {
        var review = _mapper.Map<Review>(dto);
        await _repository.AddAsync(review);

        var analysisResult = await _reviewAnalysisService.AnalyzeReviewAsync(review.Comment);

        review.Status = analysisResult;
        await _repository.UpdateAsync(review);
        return review.Id;
    }

    public async Task<bool> UpdateAsync(UpdateReviewDto dto)
    {
        var review = await _repository.GetByIdAsync(dto.Id);
        await review.EnsureNotNullAsync(id: dto.Id);

        _mapper.Map(dto, review);
        await _repository.UpdateAsync(review);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var review = await _repository.GetByIdAsync(id);
        await review.EnsureNotNullAsync(id: id);

        await _repository.DeleteAsync(review);
        return true;
    }
}
