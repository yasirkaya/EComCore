using AutoMapper;
using EComCore.Domain.DTOs.ProductToAttributeDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands;

public class DeleteAttributesByProductIdCommandHandler : IRequestHandler<DeleteAttributesByProductIdCommand>
{
    private readonly IProductToAttributeCommandService _productToAttributeCommandService;
    private readonly IMapper _mapper;
    public DeleteAttributesByProductIdCommandHandler(IProductToAttributeCommandService productToAttributeCommandService, IMapper mapper)
    {
        _productToAttributeCommandService = productToAttributeCommandService;
        _mapper = mapper;
    }

    public async Task Handle(DeleteAttributesByProductIdCommand request, CancellationToken cancellationToken)
    {
        await _productToAttributeCommandService.DeleteAttributesFromProductAsync(request.ProductId);
        return;
    }
}
