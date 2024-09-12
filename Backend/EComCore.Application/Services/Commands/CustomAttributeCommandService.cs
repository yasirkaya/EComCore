using AutoMapper;
using EComCore.Domain.DTOs.AttributeDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands;

public class CustomAttributeCommandService : ICustomAttributeCommandService
{
    private readonly IAttributeRepository _attributeRepository;
    private readonly IMapper _mapper;
    public CustomAttributeCommandService(IAttributeRepository attributeRepository, IMapper mapper)
    {
        _attributeRepository = attributeRepository;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(CreateAttributeDto dto)
    {
        var attribute = _mapper.Map<CustomAttribute>(dto);
        await _attributeRepository.AddAsync(attribute);
        return attribute.Id;
    }

    public async Task DeleteAsync(DeleteAttributeDto dto)
    {
        var attribute = await _attributeRepository.GetByIdAsync(dto.Id);
        await attribute.EnsureNotNullAsync(id: dto.Id);

        await _attributeRepository.DeleteAsync(attribute);
    }

    public async Task UpdateAsync(UpdateAttributeDto dto)
    {
        var attribute = await _attributeRepository.GetByIdAsync(dto.Id);
        await attribute.EnsureNotNullAsync(id: dto.Id);

        _mapper.Map(dto, attribute);
        await _attributeRepository.UpdateAsync(attribute);

    }
}