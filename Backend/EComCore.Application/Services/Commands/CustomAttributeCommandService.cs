using AutoMapper;
using EComCore.Domain.DTOs.AttributeDto;
using EComCore.Domain.Entities;
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

    public async Task<int> AddAsync(CreateAttribureDto dto)
    {
        var attribute = _mapper.Map<CustomAttribute>(dto);
        await _attributeRepository.AddAsync(attribute);
        return attribute.Id;
    }

    public async Task DeleteAsync(DeleteAttribureDto dto)
    {
        var attribute = await _attributeRepository.GetByIdAsync(dto.Id);
        if (attribute == null)
        {
            throw new Exception($"Attribute with Id {dto.Id} not found.");
        }

        await _attributeRepository.DeleteAsync(attribute);
    }

    public async Task UpdateAsync(UpdateAttribureDto dto)
    {
        var attribute = await _attributeRepository.GetByIdAsync(dto.Id);
        if (attribute == null)
        {
            throw new Exception($"Attribute with Id {dto.Id} not found.");
        }
        _mapper.Map(dto, attribute);
        await _attributeRepository.UpdateAsync(attribute);

    }
}