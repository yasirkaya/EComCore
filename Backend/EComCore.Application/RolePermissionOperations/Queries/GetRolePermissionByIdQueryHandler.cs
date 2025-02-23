using EComCore.Domain.Entities;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Queries
{
    public class GetRolePermissionByIdQueryHandler : IRequestHandler<GetRolePermissionByIdQuery, RolePermission>
    {
        private readonly IRolePermissionQueryService _rolePermissionQueryService;

        public GetRolePermissionByIdQueryHandler(IRolePermissionQueryService rolePermissionQueryService)
        {
            _rolePermissionQueryService = rolePermissionQueryService;
        }

        public async Task<RolePermission> Handle(GetRolePermissionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _rolePermissionQueryService.GetByIdAsync(request.Id);
        }
    }
}