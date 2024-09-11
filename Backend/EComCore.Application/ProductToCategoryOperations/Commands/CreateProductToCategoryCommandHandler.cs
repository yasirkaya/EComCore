using AutoMapper;
using EComCore.Domain.DTOs.ProductToCategoryDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Commands;

public class CreateProductToCategoryCommandHandler : IRequestHandler<CreateProductToCategoryCommand, int>
{
    private readonly IProductToCategoryCommandService _productToCategoryService;
    private readonly IMapper _mapper;
    public CreateProductToCategoryCommandHandler(IProductToCategoryCommandService productToCategoryService, IMapper mapper)
    {
        _productToCategoryService = productToCategoryService;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateProductToCategoryCommand request, CancellationToken cancellationToken)
    {
        var prodCat = _mapper.Map<CreateProductToCategoryDto>(request);
        return await _productToCategoryService.AddAsync(prodCat);
    }
}