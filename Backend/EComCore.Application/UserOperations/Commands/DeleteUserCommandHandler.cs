using AutoMapper;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.UserOperations.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserCommandService _userCommandService;
    private readonly IMapper _mapper;
    public DeleteUserCommandHandler(IUserCommandService userCommandService, IMapper mapper)
    {
        _userCommandService = userCommandService;
        _mapper = mapper;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var deleteUserDto = _mapper.Map<DeleteUserDto>(request);
        await _userCommandService.DeleteUserAsync(deleteUserDto);
        return;
    }
}