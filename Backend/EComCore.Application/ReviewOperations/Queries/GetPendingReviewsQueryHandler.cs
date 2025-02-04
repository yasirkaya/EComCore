using AutoMapper;
using EComCore.Domain.Services.Queries;
using MediatR;
using EComCore.Domain.DTOs.ReviewDTO;

namespace EComCore.Application.ReviewOperations.Queries;

public class GetPendingReviewsQueryHandler : IRequestHandler<GetPendingReviewsQuery, IEnumerable<ReviewDto>>
{
    private readonly IReviewQueryService _reviewQueryService;
    private readonly IMapper _mapper;

    public GetPendingReviewsQueryHandler(IReviewQueryService reviewQueryService, IMapper mapper)
    {
        _reviewQueryService = reviewQueryService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReviewDto>> Handle(GetPendingReviewsQuery request, CancellationToken cancellationToken)
    {
        return await _reviewQueryService.GetPendingReviewsAsync();
    }
}