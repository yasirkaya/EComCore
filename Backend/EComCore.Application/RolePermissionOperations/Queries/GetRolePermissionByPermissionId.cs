using EComCore.Domain.DTOs;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Queries;

public class GetRolePermissionByPermissionId : IRequest<IEnumerable<RolePermissionDto>>
{
    public int PermissionId { get; set; }
}
