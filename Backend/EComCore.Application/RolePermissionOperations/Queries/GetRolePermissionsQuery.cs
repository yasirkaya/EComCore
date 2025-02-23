using EComCore.Domain.Entities;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionsQuery : IRequest<IEnumerable<RolePermission>>
    {

    }
}