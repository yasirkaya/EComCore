using AutoMapper;
using EComCore.Domain.DTOs;
using EComCore.Domain.Entities;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.RoleOperations.Commands
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IRoleCommandService _roleCommandService;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IRoleCommandService roleCommandService, IMapper mapper)
        {
            _roleCommandService = roleCommandService;
            _mapper = mapper;
        }

        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<UpdateRoleDto>(request);
            await _roleCommandService.UpdateAsync(role);
            return;
        }
    }
}