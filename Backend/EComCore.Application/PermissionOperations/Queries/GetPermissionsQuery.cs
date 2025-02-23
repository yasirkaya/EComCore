using EComCore.Domain.Entities;
using MediatR;

namespace EComCore.Application.PermissionOperations.Queries;

public class GetPermissionsQuery : IRequest<IEnumerable<Permission>>
{
    public int Id { get; set; }
}
