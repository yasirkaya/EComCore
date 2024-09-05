using MediatR;

namespace EComCore.Application.AttributeValueOperations.Commands;

public class CreateAttributeValueCommand : IRequest<int>
{
    public int AttributeId { get; set; }
    public string Value { get; set; }
}