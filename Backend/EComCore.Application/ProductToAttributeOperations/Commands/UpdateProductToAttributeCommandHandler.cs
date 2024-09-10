using AutoMapper;
using EComCore.Domain.DTOs.ProductToAttributeDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands;

public class UpdateProductToAttributeCommandHandler : IRequestHandler<UpdateProductToAttributeCommand>
{
    private readonly IProductToAttributeCommandService _productToAttributeCommandService;
    private readonly IMapper _mapper;
    public UpdateProductToAttributeCommandHandler(IProductToAttributeCommandService productToAttributeCommandService, IMapper mapper)
    {
        _productToAttributeCommandService = productToAttributeCommandService;
        _mapper = mapper;
    }

    public async Task Handle(UpdateProductToAttributeCommand request, CancellationToken cancellationToken)
    {
        var prodAttr = _mapper.Map<UpdateProductToAttributeDto>(request);
        await _productToAttributeCommandService.UpdateAsync(prodAttr);
        return;
    }
}
