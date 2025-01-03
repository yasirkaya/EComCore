using AutoMapper;
using EComCore.Domain.DTOs.CartDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.CartOperations.Commands;

public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand>
{
    private readonly ICartCommandService _cartCommandService;
    private readonly IMapper _mapper;

    public UpdateCartItemCommandHandler(ICartCommandService cartCommandService, IMapper mapper)
    {
        _cartCommandService = cartCommandService;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<UpdateCartItemDto>(request);
        await _cartCommandService.UpdateCartItemAsync(dto);
    }
}