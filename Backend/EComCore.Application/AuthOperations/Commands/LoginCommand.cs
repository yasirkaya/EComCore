using EComCore.Domain.DTOs.AuthDTO;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class LoginCommand : IRequest<AuthResponseDto>
{
    public LoginDto LoginDto { get; set; }
}