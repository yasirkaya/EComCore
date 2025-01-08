using EComCore.Domain.DTOs.AuthDTO;
using EComCore.Domain.Services.Auth;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly IAuthCommandService _authCommandService;

    public LoginCommandHandler(IAuthCommandService authCommandService)
    {
        _authCommandService = authCommandService;
    }

    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _authCommandService.LoginAsync(request.LoginDto);
    }
}