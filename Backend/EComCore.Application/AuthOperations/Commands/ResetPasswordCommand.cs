using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class ResetPasswordCommand : IRequest
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; }
}