using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.UserOperations.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IUserCommandService _userCommandService;

    public UpdateUserCommandHandler(IUserCommandService userCommandService)
    {
        _userCommandService = userCommandService;
    }

    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        return await _userCommandService.UpdateUser(request.Id, request.UserDto);
    }
}