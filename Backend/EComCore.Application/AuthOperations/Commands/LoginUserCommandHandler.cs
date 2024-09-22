using AutoMapper;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthenticatedUserDto>
{
    private readonly IUserCommandService _userCommandService;
    private readonly IMapper _mapper;
    public LoginUserCommandHandler(IUserCommandService userCommandService, IMapper mapper)
    {
        _userCommandService = userCommandService;
        _mapper = mapper;
    }

    public async Task<AuthenticatedUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var loginDto = _mapper.Map<LoginDto>(request);
        return await _userCommandService.LoginAsync(loginDto);
    }
}