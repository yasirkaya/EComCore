using EComCore.Domain.DTOs.UserDTO;
using MediatR;

namespace EComCore.Application.AuthOperations.Commands;

public class RefreshTokenCommand : IRequest<AuthTokenDto>
{
    public string RefreshToken { get; set; }
}