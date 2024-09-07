using AutoMapper;
using EComCore.Domain.DTOs.AttributeValueDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AttributeValueOperations.Commands;

public class DeleteAttributeValueCommandHandler : IRequestHandler<DeleteAttributeValueCommand>
{
    private readonly IAttributeValueCommandService _commandService;
    private readonly IMapper _mapper;
    public DeleteAttributeValueCommandHandler(IAttributeValueCommandService commandService, IMapper mapper)
    {
        _commandService = commandService;
        _mapper = mapper;
    }

    public async Task Handle(DeleteAttributeValueCommand request, CancellationToken cancellationToken)
    {
        await _commandService.DeleteAsync(_mapper.Map<DeleteAttributeValueDto>(request));
        return;
    }
}