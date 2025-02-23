using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Queries;

public class GetRolePermissionByPermissionIdHandler : IRequestHandler<GetRolePermissionByPermissionId, IEnumerable<RolePermission>>
{
    private readonly IRolePermissionRepository _repository;

    public GetRolePermissionByPermissionIdHandler(IRolePermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RolePermission>> Handle(GetRolePermissionByPermissionId request, CancellationToken cancellationToken)
    {
        return await _repository.GetByPermissionIdAsync(request.PermissionId);
    }
}
