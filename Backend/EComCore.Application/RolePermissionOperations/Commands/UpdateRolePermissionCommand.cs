using MediatR;

namespace EComCore.Application.RolePermissionOperations.Commands
{
    public class UpdateRolePermissionCommand : IRequest
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}