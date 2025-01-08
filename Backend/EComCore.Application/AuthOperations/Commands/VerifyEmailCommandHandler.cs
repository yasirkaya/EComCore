using EComCore.Domain.Services.Auth;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand>
{
    private readonly IAuthCommandService _authCommandService;

    public VerifyEmailCommandHandler(IAuthCommandService authCommandService)
    {
        _authCommandService = authCommandService;
    }

    public async Task Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        await _authCommandService.VerifyEmailAsync(request.Email, request.Token);
    }
}