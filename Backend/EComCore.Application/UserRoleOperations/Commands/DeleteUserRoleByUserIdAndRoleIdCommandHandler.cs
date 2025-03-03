using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.UserRoleOperations.Commands;

public class DeleteUserRoleByUserIdAndRoleIdCommandHandler : IRequestHandler<DeleteUserRoleByUserIdAndRoleIdCommand>
{
    IUserRoleCommandService _commandService;

    public DeleteUserRoleByUserIdAndRoleIdCommandHandler(IUserRoleCommandService commandService)
    {
        _commandService = commandService;
    }

    public async Task Handle(DeleteUserRoleByUserIdAndRoleIdCommand request, CancellationToken cancellationToken)
    {
        await _commandService.DeleteUserRoleByUserIdAndRoleId(request.UserId, request.RoleId);
        return;
    }
}