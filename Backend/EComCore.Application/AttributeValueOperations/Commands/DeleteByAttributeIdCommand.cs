using MediatR;

namespace EComCore.Application.AttributeValueOperations.Commands;

public class DeleteByAttributeIdCommand : IRequest
{
    public int AttributeId { get; set; }
}