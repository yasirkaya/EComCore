using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class LogoutUserCommand : IRequest
{
    public string Email { get; set; }
}