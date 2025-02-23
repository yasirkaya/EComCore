using AutoMapper;
using EComCore.Domain.Entities;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Commands
{
    public class UpdateRolePermissionCommandHandler : IRequestHandler<UpdateRolePermissionCommand>
    {
        private readonly IRolePermissionCommandService _rolePermissionCommandService;
        private readonly IMapper _mapper;

        public UpdateRolePermissionCommandHandler(IRolePermissionCommandService rolePermissionCommandService, IMapper mapper)
        {
            _rolePermissionCommandService = rolePermissionCommandService;
            _mapper = mapper;
        }

        public async Task Handle(UpdateRolePermissionCommand request, CancellationToken cancellationToken)
        {
            var rolePermission = _mapper.Map<RolePermission>(request);
            await _rolePermissionCommandService.UpdateAsync(rolePermission);
            return;
        }
    }
}