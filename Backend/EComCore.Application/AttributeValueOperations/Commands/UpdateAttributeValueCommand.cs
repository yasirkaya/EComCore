using MediatR;

namespace EComCore.Application.AttributeValueOperations.Commands;

public class UpdateAttributeValueCommand : IRequest
{
    public int Id { get; set; }
    public int AttributeId { get; set; }
    public string? Value { get; set; }
}