using EComCore.Domain.Entities;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Queries;

public class GetRolePermissionByPermissionId : IRequest<IEnumerable<RolePermission>>
{
    public int PermissionId { get; set; }
}
