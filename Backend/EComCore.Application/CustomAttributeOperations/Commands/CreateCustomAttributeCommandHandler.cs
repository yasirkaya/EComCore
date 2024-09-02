using MediatR;
using EComCore.Domain.Services.Commands;
using AutoMapper;
using EComCore.Domain.DTOs.AttributeDto;

namespace EComCore.Application.CustomAttributeOperations.Commands;

public class CreateCustomAttributeCommandHandler : IRequestHandler<CreateCustomAttributeCommand, int>
{
    private readonly ICustomAttributeCommandService _attributeCommandService;
    private readonly IMapper _mapper;
    public CreateCustomAttributeCommandHandler(ICustomAttributeCommandService attributeCommandService, IMapper mapper)
    {
        _attributeCommandService = attributeCommandService;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCustomAttributeCommand request, CancellationToken cancellationToken)
    {
        var attribute = _mapper.Map<CreateAttribureDto>(request);

        return await _attributeCommandService.AddAsync(attribute);
    }
}