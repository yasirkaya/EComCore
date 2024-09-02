using MediatR;

namespace EComCore.Application.CustomAttributeOperations.Commands;

public class DeleteCustomAttributeCommand : IRequest
{
    public int Id { get; set; }
}