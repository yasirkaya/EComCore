using EComCore.Domain.DTOs;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Queries;

public class GetRolePermissionByPermissionIdHandler : IRequestHandler<GetRolePermissionByPermissionId, IEnumerable<RolePermissionDto>>
{
    private readonly IRolePermissionQueryService _rolePermissionQueryService;

    public GetRolePermissionByPermissionIdHandler(IRolePermissionQueryService rolePermissionQueryService)
    {
        _rolePermissionQueryService = rolePermissionQueryService;
    }

    public async Task<IEnumerable<RolePermissionDto>> Handle(GetRolePermissionByPermissionId request, CancellationToken cancellationToken)
    {
        return await _rolePermissionQueryService.GetByPermissionIdAsync(request.PermissionId);
    }
}
