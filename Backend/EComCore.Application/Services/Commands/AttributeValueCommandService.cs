using AutoMapper;
using EComCore.Domain.DTOs.AttributeValueDto;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands;

public class AttributeValueCommandService : IAttributeValueCommandService
{
    private readonly IAttributeValueRepository _attributeValueRepository;
    private readonly IMapper _mapper;
    public AttributeValueCommandService(IAttributeValueRepository attributeValueRepository, IMapper mapper)
    {
        _attributeValueRepository = attributeValueRepository;
        _mapper = mapper;
    }

    public Task<int> AddAsync(CreateAttributeValueDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(DeleteAttributeValueDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteByAttributeIdAsync(DeleteAttributeValueDto dto)
    {
        var attibuteValues = await _attributeValueRepository.GetValuesByAttributeIdAsync(dto.Id);
        if (!attibuteValues.Any())
        {
            throw new Exception("No attribute values found for the given attribute ID.");
        }
        await _attributeValueRepository.RemoveRangeAsync(attibuteValues);
    }

    public Task UpdateAsync(UpdateAttributeValueDto dto)
    {
        throw new NotImplementedException();
    }
}