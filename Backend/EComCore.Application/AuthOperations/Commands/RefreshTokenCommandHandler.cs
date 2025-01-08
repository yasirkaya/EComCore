using EComCore.Domain.DTOs.AuthDTO;
using EComCore.Domain.Services.Auth;
using EComCore.Domain.Services.Shared;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthResponseDto>
{
    private readonly IAuthCommandService _authCommandService;
    private readonly IAuthQueryService _authQueryService;
    private readonly IJwtService _jwtService;

    public RefreshTokenCommandHandler(
        IAuthCommandService authCommandService,
        IAuthQueryService authQueryService,
        IJwtService jwtService)
    {
        _authCommandService = authCommandService;
        _authQueryService = authQueryService;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var isValidToken = await _jwtService.ValidateTokenAsync(request.Token);
        if (!isValidToken)
            throw new Exception("Geçersiz token");

        var email = await _jwtService.GetEmailFromTokenAsync(request.Token);
        var user = await _authQueryService.GetCurrentUserAsync(email);

        if (user == null)
            throw new Exception("Kullanıcı bulunamadı");

        var tokenResult = await _jwtService.GenerateTokenAsync(email);
        return new AuthResponseDto
        {
            Token = tokenResult.Token,
            RefreshToken = tokenResult.RefreshToken,
            User = user
        };
    }
}