using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Commands;

public class CreateProductToCategoryCommand : IRequest<int>
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
}