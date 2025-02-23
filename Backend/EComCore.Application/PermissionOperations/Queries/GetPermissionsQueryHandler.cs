using EComCore.Domain.Entities;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.PermissionOperations.Queries;

public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, IEnumerable<Permission>>
{
    private readonly IPermissionQueryService _permissionQueryService;

    public GetPermissionsQueryHandler(IPermissionQueryService permissionQueryService)
    {
        _permissionQueryService = permissionQueryService;
    }

    public async Task<IEnumerable<Permission>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
    {
        return await _permissionQueryService.GetAllAsync();
    }
}

