using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Commands
{
    public class DeleteRolePermissionCommandHandler : IRequestHandler<DeleteRolePermissionCommand>
    {
        private readonly IRolePermissionCommandService _rolePermissionCommandService;

        public DeleteRolePermissionCommandHandler(IRolePermissionCommandService rolePermissionCommandService)
        {
            _rolePermissionCommandService = rolePermissionCommandService;
        }

        public async Task Handle(DeleteRolePermissionCommand request, CancellationToken cancellationToken)
        {
            await _rolePermissionCommandService.DeleteAsync(request.Id);
            return;
        }
    }
}