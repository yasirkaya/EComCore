using AutoMapper;
using EComCore.Domain.DTOs.AttributeDto;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.CustomAttributeOperations.Commands;

public class DeleteCustomAttributeCommandHandler : IRequestHandler<DeleteCustomAttributeCommand>
{
    private readonly ICustomAttributeCommandService _attributeCommandService;
    private readonly IMapper _mapper;
    public DeleteCustomAttributeCommandHandler(ICustomAttributeCommandService attributeCommandService, IMapper mapper)
    {
        _attributeCommandService = attributeCommandService;
        _mapper = mapper;
    }

    public async Task Handle(DeleteCustomAttributeCommand request, CancellationToken cancellationToken)
    {
        var attribute = _mapper.Map<DeleteAttribureDto>(request);
        await _attributeCommandService.DeleteAsync(attribute);
        return;
    }
}