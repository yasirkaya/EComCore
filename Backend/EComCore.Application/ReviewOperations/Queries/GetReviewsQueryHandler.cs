using AutoMapper;
using EComCore.Domain.DTOs.ReviewDTO;
using EComCore.Domain.Services.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EComCore.Application.ReviewOperations.Queries;

public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, IEnumerable<ReviewDto>>
{
    private readonly IReviewQueryService _reviewQueryService;
    private readonly IMapper _mapper;

    public GetReviewsQueryHandler(IReviewQueryService reviewQueryService, IMapper mapper)
    {
        _reviewQueryService = reviewQueryService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
    {
        return await _reviewQueryService.GetAllAsync();
    }
}
