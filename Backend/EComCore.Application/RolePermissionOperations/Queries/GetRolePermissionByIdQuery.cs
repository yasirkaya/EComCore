using EComCore.Domain.DTOs;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionByIdQuery : IRequest<RolePermissionDto>
    {
        public int Id { get; set; }
    }
}