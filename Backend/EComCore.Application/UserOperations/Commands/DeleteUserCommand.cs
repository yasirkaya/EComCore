using MediatR;

namespace EComCore.Application.UserOperations.Commands;

public class DeleteUserCommand : IRequest
{
    public int Id { get; set; }
}