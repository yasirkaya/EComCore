using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Commands;

public class DeleteProductToCategoryCommand : IRequest
{
    public int Id { get; set; }

}