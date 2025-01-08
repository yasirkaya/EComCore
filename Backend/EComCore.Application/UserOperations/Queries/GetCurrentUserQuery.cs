using EComCore.Domain.DTOs.UserDTO;
using MediatR;

namespace EComCore.Application.UserOperations.Queries;

public class GetCurrentUserQuery : IRequest<UserDto>
{
    public string Email { get; set; }
}