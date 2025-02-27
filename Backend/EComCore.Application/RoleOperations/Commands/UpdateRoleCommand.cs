using MediatR;

namespace EComCore.Application.RoleOperations.Commands
{
    public class UpdateRoleCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> PermissionIds { get; set; }
    }
}