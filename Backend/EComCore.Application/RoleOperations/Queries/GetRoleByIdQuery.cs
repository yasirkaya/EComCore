using EComCore.Domain.DTOs;
using MediatR;

namespace EComCore.Application.RoleOperations.Queries
{
    public class GetRoleByIdQuery : IRequest<RoleDto>
    {
        public int Id { get; set; }
    }
}