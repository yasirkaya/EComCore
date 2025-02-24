using AutoMapper;
using EComCore.Domain.DTOs.UserRoleDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.UserRoleOperations.Commands;

public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand>
{
    private readonly IUserRoleCommandService _commandService;
    private readonly IMapper _mapper;

    public UpdateUserRoleCommandHandler(IUserRoleCommandService commandService, IMapper mapper)
    {
        _commandService = commandService;
        _mapper = mapper;
    }

    public async Task Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userRole = _mapper.Map<UpdateUserRoleDto>(request);
        await _commandService.UpdateAsync(userRole);
        return;
    }
}