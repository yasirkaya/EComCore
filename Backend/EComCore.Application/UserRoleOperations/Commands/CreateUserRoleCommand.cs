using EComCore.Domain.DTOs.UserRoleDTO;
using MediatR;

namespace EComCore.Application.UserRoleOperations.Commands
{
    public class CreateUserRoleCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}