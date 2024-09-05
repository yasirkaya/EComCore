using AutoMapper;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.AttributeValueOperations.Commands;

public class DeleteByAttributeIdCommandHandler : IRequestHandler<DeleteByAttributeIdCommand>
{
    private readonly IAttributeValueCommandService _commandService;
    private readonly IMapper _mapper;
    public DeleteByAttributeIdCommandHandler(IAttributeValueCommandService commandService, IMapper mapper)
    {
        _commandService = commandService;
        _mapper = mapper;
    }

    public async Task Handle(DeleteByAttributeIdCommand request, CancellationToken cancellationToken)
    {
        await _commandService.DeleteByAttributeIdAsync(request.AttributeId);
        return;
    }
}