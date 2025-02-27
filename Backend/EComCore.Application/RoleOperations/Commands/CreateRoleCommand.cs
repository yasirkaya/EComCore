using MediatR;

namespace EComCore.Application.RoleOperations.Commands
{
    public class CreateRoleCommand : IRequest
    {
        public string Name { get; set; }
        public IEnumerable<int> PermissionIds { get; set; }
    }
}