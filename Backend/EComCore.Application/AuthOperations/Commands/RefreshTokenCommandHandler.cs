using AutoMapper;
using EComCore.Domain.DTOs.AuthDTO;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Commands;
using EComCore.Domain.Services.Shared;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthTokenDto>
{
    private readonly IJwtService _jwtService;
    private readonly IUserCommandService _userCommandService;
    private readonly IMapper _mapper;
    public RefreshTokenCommandHandler(IJwtService jwtService, IMapper mapper, IUserCommandService userCommandService)
    {
        _jwtService = jwtService;
        _mapper = mapper;
        _userCommandService = userCommandService;
    }

    public async Task<AuthTokenDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return new AuthTokenDto();
    }
}