using AutoMapper;
using EComCore.Domain.DTOs.AttributeValueDto;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AttributeValueOperations.Commands;

public class CreateAttributeValueCommandHandler : IRequestHandler<CreateAttributeValueCommand, int>
{
    private readonly IAttributeValueCommandService _commandService;
    private readonly IMapper _mapper;
    public CreateAttributeValueCommandHandler(IAttributeValueCommandService commandService, IMapper mapper)
    {
        _commandService = commandService;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateAttributeValueCommand request, CancellationToken cancellationToken)
    {
        var attributeValue = _mapper.Map<CreateAttributeValueDto>(request);
        return await _commandService.AddAsync(attributeValue);
    }
}