using MediatR;

namespace EComCore.Application.RolePermissionOperations.Commands
{
    public class DeleteRolePermissionCommand : IRequest
    {
        public int Id { get; set; }
    }
}