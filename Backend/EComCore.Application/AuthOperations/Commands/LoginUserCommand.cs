using EComCore.Domain.DTOs.UserDTO;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class LoginUserCommand : IRequest<AuthenticatedUserDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}