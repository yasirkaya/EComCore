using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand>
{
    private readonly IUserCommandService _userCommandService;
    public LogoutUserCommandHandler(IUserCommandService userCommandService)
    {
        _userCommandService = userCommandService;
    }

    public async Task Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        await _userCommandService.LogoutAsync(request.Email);

        return;
    }
}