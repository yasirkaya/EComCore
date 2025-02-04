using AutoMapper;
using EComCore.Domain.Services.Queries;
using MediatR;
using EComCore.Domain.DTOs.ReviewDTO;

namespace EComCore.Application.ReviewOperations.Queries;

public class GetReviewsByProductIdQueryHandler : IRequestHandler<GetReviewsByProductIdQuery, IEnumerable<ReviewDto>>
{
    private readonly IReviewQueryService _reviewQueryService;
    private readonly IMapper _mapper;

    public GetReviewsByProductIdQueryHandler(IReviewQueryService reviewQueryService, IMapper mapper)
    {
        _reviewQueryService = reviewQueryService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsByProductIdQuery request, CancellationToken cancellationToken)
    {
        return await _reviewQueryService.GetByProductIdAsync(request.ProductId);
    }
}