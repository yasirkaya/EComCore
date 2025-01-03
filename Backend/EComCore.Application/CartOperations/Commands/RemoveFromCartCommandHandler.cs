using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.CartOperations.Commands;

public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand>
{
    private readonly ICartCommandService _cartCommandService;

    public RemoveFromCartCommandHandler(ICartCommandService cartCommandService)
    {
        _cartCommandService = cartCommandService;
    }

    public async Task Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
    {
        await _cartCommandService.RemoveFromCartAsync(request.UserId, request.ProductId);
    }
}