using AutoMapper;
using EComCore.Domain.Services.Queries;
using MediatR;
using EComCore.Domain.DTOs.ReviewDTO;

namespace EComCore.Application.ReviewOperations.Queries;

public class GetReviewsByUserIdQueryHandler : IRequestHandler<GetReviewsByUserIdQuery, IEnumerable<ReviewDto>>
{
    private readonly IReviewQueryService _reviewQueryService;
    private readonly IMapper _mapper;

    public GetReviewsByUserIdQueryHandler(IReviewQueryService reviewQueryService, IMapper mapper)
    {
        _reviewQueryService = reviewQueryService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await _reviewQueryService.GetByUserIdAsync(request.UserId);
    }
}