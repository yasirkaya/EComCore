using AutoMapper;
using EComCore.Domain.Entities;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.PermissionOperations.Commands
{
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand>
    {
        private readonly IPermissionCommandService _permissionCommandService;
        private readonly IMapper _mapper;

        public CreatePermissionCommandHandler(IPermissionCommandService permissionCommandService, IMapper mapper)
        {
            _permissionCommandService = permissionCommandService;
            _mapper = mapper;
        }

        public async Task Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = _mapper.Map<Permission>(request);
            await _permissionCommandService.CreateAsync(permission);
            return;
        }
    }
}