using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Commands;

public class DeleteProductFromCategoriesCommand : IRequest
{
    public int ProductId { get; set; }

}