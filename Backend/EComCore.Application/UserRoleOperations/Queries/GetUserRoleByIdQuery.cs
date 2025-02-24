using EComCore.Domain.DTOs.UserRoleDTO;
using MediatR;

namespace EComCore.Application.Features.UserRoles.Queries
{
    public class GetUserRoleByIdQuery : IRequest<UserRoleDetailsDto>
    {
        public int Id { get; set; }
    }
}
