using MediatR;

namespace EComCore.Application.AttributeValueOperations.Commands;

public class DeleteAttributeValueCommand : IRequest
{
    public int Id { get; set; }
}