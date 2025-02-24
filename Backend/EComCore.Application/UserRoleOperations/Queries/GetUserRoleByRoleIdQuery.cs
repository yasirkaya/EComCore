using EComCore.Domain.DTOs.UserRoleDTO;
using MediatR;

namespace EComCore.Application.Features.UserRoles.Queries
{
    public class GetUserRoleByRoleIdQuery : IRequest<IEnumerable<UserRoleDetailsDto>>
    {
        public int RoleId { get; set; }
    }
}
