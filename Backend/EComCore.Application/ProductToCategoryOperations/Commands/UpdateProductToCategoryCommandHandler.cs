using AutoMapper;
using EComCore.Domain.DTOs.ProductToCategoryDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Commands;

public class UpdateProductToCategoryCommandHandler : IRequestHandler<UpdateProductToCategoryCommand>
{
    private readonly IProductToCategoryCommandService _productToCategoryService;
    private readonly IMapper _mapper;
    public UpdateProductToCategoryCommandHandler(IProductToCategoryCommandService productToCategoryService, IMapper mapper)
    {
        _productToCategoryService = productToCategoryService;
        _mapper = mapper;
    }

    public async Task Handle(UpdateProductToCategoryCommand request, CancellationToken cancellationToken)
    {
        var prodCat = _mapper.Map<UpdateProductToCategoryDto>(request);
        await _productToCategoryService.UpdateAsync(prodCat);
        return;
    }
}