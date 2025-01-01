using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class VerifyEmailCommand : IRequest
{
    public string Email { get; set; }
    public string Token { get; set; }
}