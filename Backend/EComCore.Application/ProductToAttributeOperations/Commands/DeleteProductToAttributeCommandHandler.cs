using AutoMapper;
using EComCore.Domain.DTOs.ProductToAttributeDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands;

public class DeleteProductToAttributeCommandHandler : IRequestHandler<DeleteProductToAttributeCommand>
{
    private readonly IProductToAttributeCommandService _productToAttributeCommandService;
    private readonly IMapper _mapper;
    public DeleteProductToAttributeCommandHandler(IProductToAttributeCommandService productToAttributeCommandService, IMapper mapper)
    {
        _productToAttributeCommandService = productToAttributeCommandService;
        _mapper = mapper;
    }

    public async Task Handle(DeleteProductToAttributeCommand request, CancellationToken cancellationToken)
    {
        await _productToAttributeCommandService.DeleteAsync(_mapper.Map<DeleteProductToAttributeDto>(request));
        return;
    }
}
