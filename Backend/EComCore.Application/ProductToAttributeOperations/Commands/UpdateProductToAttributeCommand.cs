using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands;

public class UpdateProductToAttributeCommand : IRequest
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int AttributeId { get; set; }
    public int AttributeValueId { get; set; }

}