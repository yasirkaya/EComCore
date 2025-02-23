using EComCore.Application.Interfaces;
using EComCore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionByRoleIdHandler : IRequestHandler<GetRolePermissionByRoleId, IEnumerable<RolePermission>>
    {
        private readonly IRolePermissionQueryService _rolePermissionQueryService;

        public GetRolePermissionByRoleIdHandler(IRolePermissionQueryService rolePermissionQueryService)
        {
            _rolePermissionQueryService = rolePermissionQueryService;
        }

        public async Task<IEnumerable<RolePermission>> Handle(GetRolePermissionByRoleId request, CancellationToken cancellationToken)
        {
            return await _rolePermissionQueryService.GetByRoleIdAsync(request.RoleId);
        }
    }
}
