using EComCore.Domain.Entities;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.PermissionOperations.Queries;

public class GetPermissionByIdQueryHandler : IRequestHandler<GetPermissionByIdQuery, Permission>
{
    private readonly IPermissionQueryService _permissionQueryService;

    public GetPermissionByIdQueryHandler(IPermissionQueryService permissionQueryService)
    {
        _permissionQueryService = permissionQueryService;
    }

    public async Task<Permission> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _permissionQueryService.GetByIdAsync(request.Id);
    }
}
