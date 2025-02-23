using EComCore.Domain.Entities;
using EComCore.Domain.Services.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionsQueryHandler : IRequestHandler<GetRolePermissionsQuery, IEnumerable<RolePermission>>
    {
        private readonly IRolePermissionQueryService _rolePermissionQueryService;

        public GetRolePermissionsQueryHandler(IRolePermissionQueryService rolePermissionQueryService)
        {
            _rolePermissionQueryService = rolePermissionQueryService;
        }

        public async Task<IEnumerable<RolePermission>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
        {
            return await _rolePermissionQueryService.GetAllAsync();
        }
    }
}