using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Commands;

public class UpdateProductToCategoryCommand : IRequest
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
}