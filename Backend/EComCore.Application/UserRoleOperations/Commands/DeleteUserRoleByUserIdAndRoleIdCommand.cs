using MediatR;

namespace EComCore.Application.UserRoleOperations.Commands;

public class DeleteUserRoleByUserIdAndRoleIdCommand : IRequest
{
    public int UserId { get; set; }
    public int RoleId { get; set; }

}