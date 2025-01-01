using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
{
    private readonly IUserCommandService _userCommandService;

    public ResetPasswordCommandHandler(IUserCommandService userCommandService)
    {
        _userCommandService = userCommandService;
    }

    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        await _userCommandService.ResetPasswordAsync(request.Email, request.Token, request.NewPassword);
        return;
    }
}