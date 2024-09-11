using AutoMapper;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Commands;

public class DeleteProductFromCategoriesCommandHandler : IRequestHandler<DeleteProductFromCategoriesCommand>
{
    private readonly IProductToCategoryCommandService _productToCategoryService;
    public DeleteProductFromCategoriesCommandHandler(IProductToCategoryCommandService productToCategoryService)
    {
        _productToCategoryService = productToCategoryService;
    }

    public async Task Handle(DeleteProductFromCategoriesCommand request, CancellationToken cancellationToken)
    {

        await _productToCategoryService.DeleteProductFromCategoriesAsync(request.ProductId);
        return;
    }
}