using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands;

public class CreateProductToAttributeCommand : IRequest<int>
{
    public int ProductId { get; set; }
    public int AttributeId { get; set; }
    public int AttributeValueId { get; set; }
}