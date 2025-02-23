using AutoMapper;
using EComCore.Domain.Entities;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.RolePermissionOperations.Commands;

public class CreateRolePermissionCommandHandler : IRequestHandler<CreateRolePermissionCommand>
{
    private readonly IRolePermissionCommandService _rolePermissionService;
    private readonly IMapper _mapper;
    public CreateRolePermissionCommandHandler(IRolePermissionCommandService rolePermissionService, IMapper mapper)
    {
        _rolePermissionService = rolePermissionService;
        _mapper = mapper;
    }

    public async Task Handle(CreateRolePermissionCommand request, CancellationToken cancellationToken)
    {
        var rolePermission = _mapper.Map<RolePermission>(request);
        await _rolePermissionService.AddAsync(rolePermission);

        return;
    }
}