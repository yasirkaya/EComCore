using EComCore.Domain.Services.Auth;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand>
{
    private readonly IAuthCommandService _authCommandService;

    public LogoutUserCommandHandler(IAuthCommandService authCommandService)
    {
        _authCommandService = authCommandService;
    }

    public async Task Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        await _authCommandService.LogoutAsync(request.Email);
    }
}