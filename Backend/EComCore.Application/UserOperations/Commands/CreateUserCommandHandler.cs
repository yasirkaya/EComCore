using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.UserOperations.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserCommandService _userCommandService;

    public CreateUserCommandHandler(IUserCommandService userCommandService)
    {
        _userCommandService = userCommandService;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await _userCommandService.CreateUser(request.UserDto);
    }
}