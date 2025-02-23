using EComCore.Domain.DTOs;
using EComCore.Domain.Entities;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionsQueryHandler : IRequestHandler<GetRolePermissionsQuery, IEnumerable<RolePermissionDto>>
    {
        private readonly IRolePermissionQueryService _rolePermissionQueryService;

        public GetRolePermissionsQueryHandler(IRolePermissionQueryService rolePermissionQueryService)
        {
            _rolePermissionQueryService = rolePermissionQueryService;
        }

        public async Task<IEnumerable<RolePermissionDto>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
        {
            return await _rolePermissionQueryService.GetAllAsync();
        }
    }
}