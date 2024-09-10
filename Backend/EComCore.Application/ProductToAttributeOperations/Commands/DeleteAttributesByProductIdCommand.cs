using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands;

public class DeleteAttributesByProductIdCommand : IRequest
{
    public int ProductId { get; set; }

}