using MediatR;

namespace EComCore.Application.RoleOperations.Commands
{
    public class DeleteRoleCommand : IRequest
    {
        public int Id { get; set; }
    }
}