using EComCore.Domain.Services.Auth;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
{
    private readonly IAuthCommandService _authCommandService;

    public ResetPasswordCommandHandler(IAuthCommandService authCommandService)
    {
        _authCommandService = authCommandService;
    }

    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        await _authCommandService.ResetPasswordAsync(request.Email, request.Token, request.NewPassword);
    }
}