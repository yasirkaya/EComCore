using AutoMapper;
using EComCore.Domain.DTOs;
using EComCore.Domain.Entities;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.RoleOperations.Commands
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
    {
        private readonly IRoleCommandService _roleCommandService;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IRoleCommandService roleCommandService, IMapper mapper)
        {
            _roleCommandService = roleCommandService;
            _mapper = mapper;
        }

        public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<CreateRoleDto>(request);
            await _roleCommandService.CreateAsync(role);
            return;
        }
    }
}