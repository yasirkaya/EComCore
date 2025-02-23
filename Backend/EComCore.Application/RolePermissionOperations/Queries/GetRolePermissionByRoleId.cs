using MediatR;
using EComCore.Domain.Entities;
using EComCore.Domain.DTOs;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionByRoleId : IRequest<IEnumerable<RolePermissionDto>>
    {
        public int RoleId { get; set; }

    }
}
