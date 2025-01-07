using EComCore.Domain.DTOs.UserDTO;
using MediatR;

namespace EComCore.Application.UserOperations.Commands;

public class CreateUserCommand : IRequest<UserDto>
{
    public CreateUserDto UserDto { get; set; }
}

