using AutoMapper;
using EComCore.Domain.DTOs.ReviewDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ReviewOperations.Commands;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, bool>
{
    private readonly IReviewCommandService _reviewCommandService;
    private readonly IMapper _mapper;

    public DeleteReviewCommandHandler(IReviewCommandService reviewCommandService, IMapper mapper)
    {
        _reviewCommandService = reviewCommandService;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        return await _reviewCommandService.DeleteAsync(request.Id);
    }
}