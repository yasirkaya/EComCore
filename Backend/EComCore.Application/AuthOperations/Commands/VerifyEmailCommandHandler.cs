using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand>
{
    private readonly IUserCommandService _userCommandService;

    public VerifyEmailCommandHandler(IUserCommandService userCommandService)
    {
        _userCommandService = userCommandService;
    }

    public async Task Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        await _userCommandService.VerifyEmailAsync(request.Email, request.Token);
        return;
    }
}