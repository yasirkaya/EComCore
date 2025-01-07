using EComCore.Domain.DTOs.UserDTO;
using MediatR;

namespace EComCore.Application.UserOperations.Queries;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
}