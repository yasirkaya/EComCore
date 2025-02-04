using AutoMapper;
using EComCore.Domain.DTOs.ReviewDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.ReviewOperations.Queries;

public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ReviewDto>
{
    private readonly IReviewQueryService _reviewQueryService;

    public GetReviewByIdQueryHandler(IReviewQueryService reviewQueryService)
    {
        _reviewQueryService = reviewQueryService;
    }

    public async Task<ReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        return await _reviewQueryService.GetByIdAsync(request.Id);
    }
}
