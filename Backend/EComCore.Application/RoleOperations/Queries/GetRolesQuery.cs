using EComCore.Domain.DTOs;
using MediatR;

namespace EComCore.Application.RoleOperations.Queries
{
    public class GetRolesQuery : IRequest<IEnumerable<RoleDto>>
    {
    }
}