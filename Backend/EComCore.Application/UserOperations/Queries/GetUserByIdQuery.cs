using EComCore.Domain.DTOs.UserDTO;
using MediatR;

namespace EComCore.Application.UserOperations.Queries;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public int Id { get; set; }
}