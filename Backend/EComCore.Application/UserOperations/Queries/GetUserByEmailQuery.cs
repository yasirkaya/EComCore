using EComCore.Domain.DTOs.UserDTO;
using MediatR;

namespace EComCore.Application.UserOperations.Queries;

public class GetUserByEmailQuery : IRequest<UserDto>
{
    public string Email { get; set; }
}