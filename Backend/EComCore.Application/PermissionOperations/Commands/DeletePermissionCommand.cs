using MediatR;

namespace EComCore.Application.PermissionOperations.Commands
{
    public class DeletePermissionCommand : IRequest
    {
        public int Id { get; set; }
    }
}