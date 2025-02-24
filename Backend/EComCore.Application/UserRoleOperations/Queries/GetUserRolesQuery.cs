using EComCore.Domain.DTOs.UserRoleDTO;
using MediatR;

namespace EComCore.Application.Features.UserRoles.Queries
{
    public class GetUserRolesQuery : IRequest<IEnumerable<UserRoleDetailsDto>>
    {
    }
}
