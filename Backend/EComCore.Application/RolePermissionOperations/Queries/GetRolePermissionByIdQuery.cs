using EComCore.Domain.Entities;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionByIdQuery : IRequest<RolePermission>
    {
        public int Id { get; set; }
    }
}