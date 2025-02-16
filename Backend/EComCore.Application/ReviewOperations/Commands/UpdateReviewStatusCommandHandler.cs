using AutoMapper;
using EComCore.Domain.DTOs.ReviewDTO;
using EComCore.Domain.Services.Commands;
using MediatR;


namespace EComCore.Application.ReviewOperations.Commands
{
    public class UpdateReviewStatusCommandHandler : IRequestHandler<UpdateReviewStatusCommand, bool>
    {
        private readonly IReviewCommandService _reviewCommandService;
        private readonly IMapper _mapper;


        public UpdateReviewStatusCommandHandler(IReviewCommandService reviewCommandService, IMapper mapper)
        {
            _reviewCommandService = reviewCommandService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateReviewStatusCommand request, CancellationToken cancellationToken)
        {
            return await _reviewCommandService.UpdateStatusAsync(_mapper.Map<UpdateStatusDto>(request));
        }
    }
}