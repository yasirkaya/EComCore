using MediatR;

namespace EComCore.Application.RolePermissionOperations.Commands
{
    public class CreateRolePermissionCommand : IRequest
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}