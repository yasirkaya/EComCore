using MediatR;

namespace EComCore.Application.PermissionOperations.Commands
{
    public class UpdatePermissionCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}