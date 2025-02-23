using MediatR;
using EComCore.Domain.Entities;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionByRoleId : IRequest<IEnumerable<RolePermission>>
    {
        public int RoleId { get; set; }

    }
}
