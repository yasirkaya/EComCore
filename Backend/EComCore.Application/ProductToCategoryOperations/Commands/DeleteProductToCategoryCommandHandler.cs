using AutoMapper;
using EComCore.Domain.DTOs.ProductToCategoryDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Commands;

public class DeleteProductToCategoryCommandHandler : IRequestHandler<DeleteProductToCategoryCommand>
{
    private readonly IProductToCategoryCommandService _productToCategoryService;
    private readonly IMapper _mapper;
    public DeleteProductToCategoryCommandHandler(IProductToCategoryCommandService productToCategoryService, IMapper mapper)
    {
        _productToCategoryService = productToCategoryService;
        _mapper = mapper;
    }

    public async Task Handle(DeleteProductToCategoryCommand request, CancellationToken cancellationToken)
    {
        var prodCat = _mapper.Map<DeleteProductToCategoryDto>(request);
        await _productToCategoryService.DeleteAsync(prodCat);
        return;
    }
}