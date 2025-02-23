using EComCore.Domain.DTOs;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionsQuery : IRequest<IEnumerable<RolePermissionDto>>
    {

    }
}