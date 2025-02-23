using EComCore.Domain.Entities;
using MediatR;

namespace EComCore.Application.PermissionOperations.Queries
{
    public class GetPermissionByIdQuery : IRequest<Permission>
    {
        public int Id { get; set; }
    }
}