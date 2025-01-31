using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.CartOperations.Commands;

public class ClearCartCommandHandler : IRequestHandler<ClearCartCommand>
{
    private readonly ICartCommandService _cartCommandService;
    public ClearCartCommandHandler(ICartCommandService cartCommandService)
    {
        _cartCommandService = cartCommandService;
    }

    public async Task Handle(ClearCartCommand request, CancellationToken cancellationToken)
    {
        await _cartCommandService.ClearCartAsync(request.UserId);
        return;
    }
}