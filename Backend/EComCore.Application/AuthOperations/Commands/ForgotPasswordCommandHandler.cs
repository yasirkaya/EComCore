using EComCore.Domain.Services.Auth;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
{
    private readonly IAuthCommandService _authCommandService;

    public ForgotPasswordCommandHandler(IAuthCommandService authCommandService)
    {
        _authCommandService = authCommandService;
    }

    public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        await _authCommandService.ForgotPasswordAsync(request.Email);
    }
}