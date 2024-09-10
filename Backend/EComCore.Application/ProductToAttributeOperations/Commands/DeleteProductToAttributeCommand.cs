using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands;

public class DeleteProductToAttributeCommand : IRequest
{
    public int Id { get; set; }

}