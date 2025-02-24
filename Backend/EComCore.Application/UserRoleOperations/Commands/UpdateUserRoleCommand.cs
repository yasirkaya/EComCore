using MediatR;

namespace EComCore.Application.UserRoleOperations.Commands
{
    public class UpdateUserRoleCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}