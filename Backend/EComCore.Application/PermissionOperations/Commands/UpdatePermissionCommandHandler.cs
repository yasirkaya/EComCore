using AutoMapper;
using EComCore.Domain.Entities;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.PermissionOperations.Commands
{
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand>
    {
        private readonly IPermissionCommandService _permissionCommandService;
        private readonly IMapper _mapper;

        public UpdatePermissionCommandHandler(IPermissionCommandService permissionCommandService, IMapper mapper)
        {
            _permissionCommandService = permissionCommandService;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = _mapper.Map<Permission>(request);
            await _permissionCommandService.UpdateAsync(permission);
            return;
        }
    }
}