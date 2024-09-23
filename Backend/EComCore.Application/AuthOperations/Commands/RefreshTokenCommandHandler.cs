using AutoMapper;
using EComCore.Domain.DTOs.AuthDTO;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Commands;
using EComCore.Domain.Services.Queries;
using EComCore.Domain.Services.Shared;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthTokenDto>
{
    private readonly IJwtService _jwtService;
    private readonly IUserQueryService _userQueryService;
    public RefreshTokenCommandHandler(IJwtService jwtService, IUserQueryService userQueryService)
    {
        _jwtService = jwtService;
        _userQueryService = userQueryService;
    }

    public async Task<AuthTokenDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userQueryService.GetByRefreshTokenAsync(request.RefreshToken);

        return await _jwtService.GenerateTokenAsync(user.Email);



    }
}