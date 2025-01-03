using AutoMapper;
using EComCore.Domain.DTOs.CartDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.CartOperations.Commands;

public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, int>
{
    private readonly ICartCommandService _cartCommandService;
    private readonly IMapper _mapper;

    public AddToCartCommandHandler(ICartCommandService cartCommandService, IMapper mapper)
    {
        _cartCommandService = cartCommandService;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<AddToCartDto>(request);
        return await _cartCommandService.AddToCartAsync(dto);
    }
}