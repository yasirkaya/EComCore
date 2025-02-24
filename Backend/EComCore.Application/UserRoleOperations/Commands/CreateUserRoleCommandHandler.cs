using AutoMapper;
using EComCore.Domain.DTOs.UserRoleDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.UserRoleOperations.Commands;

public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, int>
{
    private readonly IUserRoleCommandService _commandService;
    private readonly IMapper _mapper;

    public CreateUserRoleCommandHandler(IUserRoleCommandService commandService, IMapper mapper)
    {
        _commandService = commandService;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userRole = _mapper.Map<CreateUserRoleDto>(request);
        return await _commandService.AddAsync(userRole);
    }
}