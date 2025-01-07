using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.UserOperations.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserCommandService _userCommandService;

    public DeleteUserCommandHandler(IUserCommandService userCommandService)
    {
        _userCommandService = userCommandService;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userCommandService.DeleteUser(request.Id);
        return Unit.Value;
    }
}