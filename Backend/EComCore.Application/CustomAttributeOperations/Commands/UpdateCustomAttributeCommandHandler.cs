using AutoMapper;
using EComCore.Domain.DTOs.AttributeDTO;
using EComCore.Domain.Services.Commands;
using MediatR;

namespace EComCore.Application.CustomAttributeOperations.Commands;

public class UpdateCustomAttributeCommandHandler : IRequestHandler<UpdateCustomAttributeCommand>
{
    private readonly ICustomAttributeCommandService _commandService;
    private readonly IMapper _mapper;
    public UpdateCustomAttributeCommandHandler(ICustomAttributeCommandService commandService, IMapper mapper)
    {
        _commandService = commandService;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCustomAttributeCommand request, CancellationToken cancellationToken)
    {
        var attribute = _mapper.Map<UpdateAttributeDto>(request);
        await _commandService.UpdateAsync(attribute);
        return;
    }
}