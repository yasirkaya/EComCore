using MediatR;

namespace EComCore.Application.CustomAttributeOperations.Commands;

public class UpdateCustomAttributeCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

}