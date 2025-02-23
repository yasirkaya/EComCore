using MediatR;

namespace EComCore.Application.PermissionOperations.Commands;

public class CreatePermissionCommand : IRequest
{
    public string Name { get; set; }
}
