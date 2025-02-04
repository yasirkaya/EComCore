using AutoMapper;
using EComCore.Domain.DTOs.ReviewDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ReviewOperations.Commands;

public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, bool>
{
    private readonly IReviewCommandService _reviewCommandService;
    private readonly IMapper _mapper;

    public UpdateReviewCommandHandler(IReviewCommandService reviewCommandService, IMapper mapper)
    {
        _reviewCommandService = reviewCommandService;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        return await _reviewCommandService.UpdateAsync(_mapper.Map<UpdateReviewDto>(request));
    }
}