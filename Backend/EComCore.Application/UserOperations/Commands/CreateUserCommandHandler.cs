using AutoMapper;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.UserOperations.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserCommandService _userCommandService;
    private readonly IMapper _mapper;
    public CreateUserCommandHandler(IUserCommandService userCommandService, IMapper mapper)
    {
        _userCommandService = userCommandService;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<CreateUserDto>(request);
        return await _userCommandService.RegisterAsync(user);
    }
}