using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
{
    private readonly IUserCommandService _userCommandService;

    public ForgotPasswordCommandHandler(IUserCommandService userCommandService)
    {
        _userCommandService = userCommandService;
    }

    public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        await _userCommandService.ForgotPasswordAsync(request.Email);
        return;
    }
}