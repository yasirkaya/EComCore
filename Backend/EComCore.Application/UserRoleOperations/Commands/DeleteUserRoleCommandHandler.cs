using AutoMapper;
using EComCore.Domain.DTOs.UserRoleDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.UserRoleOperations.Commands;

public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand>
{
    private readonly IUserRoleCommandService _commandService;
    private readonly IMapper _mapper;

    public DeleteUserRoleCommandHandler(IUserRoleCommandService commandService, IMapper mapper)
    {
        _commandService = commandService;
        _mapper = mapper;
    }

    public async Task Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _commandService.DeleteAsync(_mapper.Map<DeleteUserRoleDto>(request));
        return;
    }
}