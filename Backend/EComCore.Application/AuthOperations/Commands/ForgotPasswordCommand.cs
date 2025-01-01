using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class ForgotPasswordCommand : IRequest
{
    public string Email { get; set; }
}