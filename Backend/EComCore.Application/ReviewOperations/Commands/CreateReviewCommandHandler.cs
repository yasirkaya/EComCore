using AutoMapper;
using EComCore.Domain.DTOs.ReviewDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ReviewOperations.Commands;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
{
    private readonly IReviewCommandService _reviewCommandService;
    private readonly IMapper _mapper;

    public CreateReviewCommandHandler(IReviewCommandService reviewCommandService, IMapper mapper)
    {
        _reviewCommandService = reviewCommandService;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        return await _reviewCommandService.CreateAsync(_mapper.Map<CreateReviewDto>(request));
    }
}