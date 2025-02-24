using EComCore.Domain.DTOs.UserRoleDTO;
using MediatR;

namespace EComCore.Application.Features.UserRoles.Queries
{
    public class GetUserRoleByUserIdQuery : IRequest<IEnumerable<UserRoleDetailsDto>>
    {
        public int UserId { get; set; }
    }
}
