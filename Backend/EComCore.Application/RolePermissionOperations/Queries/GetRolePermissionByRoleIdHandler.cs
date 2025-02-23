using MediatR;
using EComCore.Domain.Services.Queries;
using EComCore.Domain.DTOs;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionByRoleIdHandler : IRequestHandler<GetRolePermissionByRoleId, IEnumerable<RolePermissionDto>>
    {
        private readonly IRolePermissionQueryService _rolePermissionQueryService;

        public GetRolePermissionByRoleIdHandler(IRolePermissionQueryService rolePermissionQueryService)
        {
            _rolePermissionQueryService = rolePermissionQueryService;
        }

        public async Task<IEnumerable<RolePermissionDto>> Handle(GetRolePermissionByRoleId request, CancellationToken cancellationToken)
        {
            return await _rolePermissionQueryService.GetByRoleIdAsync(request.RoleId);
        }
    }
}
