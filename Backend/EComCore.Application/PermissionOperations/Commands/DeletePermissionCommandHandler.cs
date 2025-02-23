using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.PermissionOperations.Commands
{
    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand>
    {
        private readonly IPermissionCommandService _permissionCommandService;

        public DeletePermissionCommandHandler(IPermissionCommandService permissionCommandService)
        {
            _permissionCommandService = permissionCommandService;
        }

        public async Task Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            await _permissionCommandService.DeleteAsync(request.Id);
            return;
        }
    }
}