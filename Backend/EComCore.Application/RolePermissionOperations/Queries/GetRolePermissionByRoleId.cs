using MediatR;
using EComCore.Domain.Entities;
using System.Collections.Generic;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionByRoleId : IRequest<IEnumerable<RolePermission>>
    {
        public int RoleId { get; set; }

    }
}
