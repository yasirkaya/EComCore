using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.RoleOperations.Commands
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IRoleCommandService _roleCommandService;

        public DeleteRoleCommandHandler(IRoleCommandService roleCommandService)
        {
            _roleCommandService = roleCommandService;
        }

        public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleCommandService.DeleteAsync(request.Id);
            return;
        }
    }
}