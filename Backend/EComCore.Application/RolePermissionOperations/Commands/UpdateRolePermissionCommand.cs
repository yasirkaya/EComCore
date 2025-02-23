using MediatR;

namespace EComCore.Application.RolePermissionOperations.Commands
{
    public class UpdateRolePermissionCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}