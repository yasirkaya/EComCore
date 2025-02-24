using MediatR;

namespace EComCore.Application.UserRoleOperations.Commands
{
    public class DeleteUserRoleCommand : IRequest
    {
        public int Id { get; set; }
    }
}