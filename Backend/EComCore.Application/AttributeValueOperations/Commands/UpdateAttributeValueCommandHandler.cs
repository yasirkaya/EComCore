using AutoMapper;
using EComCore.Domain.DTOs.AttributeValueDto;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AttributeValueOperations.Commands;

public class UpdateAttributeValueCommandHandler : IRequestHandler<UpdateAttributeValueCommand>
{
    private readonly IAttributeValueCommandService _commandService;
    private readonly IMapper _mapper;
    public UpdateAttributeValueCommandHandler(IAttributeValueCommandService commandService, IMapper mapper)
    {
        _commandService = commandService;
        _mapper = mapper;
    }

    public async Task Handle(UpdateAttributeValueCommand request, CancellationToken cancellationToken)
    {
        await _commandService.UpdateAsync(_mapper.Map<UpdateAttributeValueDto>(request));
        return;
    }
}