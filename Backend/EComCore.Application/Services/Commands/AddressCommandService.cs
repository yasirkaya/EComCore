using AutoMapper;
using EComCore.Domain.DTOs.AddressDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands;

public class AddressCommandService : IAddressCommandService
{
    private readonly IAddressRepository _repodsitory;
    private readonly IMapper _mapper;
    public AddressCommandService(IAddressRepository repodsitory, IMapper mapper)
    {
        _repodsitory = repodsitory;
        _mapper = mapper;
    }

    public async Task<int> CreateAddressAsync(CreateAddressDto dto)
    {
        var address = _mapper.Map<Address>(dto);
        await _repodsitory.AddAsync(address);
        return address.Id;
    }

    public async Task DeleteAddressAsync(DeleteAddressDto dto)
    {
        var address = await _repodsitory.GetByIdAsync(dto.Id);
        await address.EnsureNotNullAsync(id: dto.Id);

        await _repodsitory.DeleteAsync(address);
    }

    public async Task UpdateAddressAsync(UpdateAddressDto dto)
    {
        var address = await _repodsitory.GetByIdAsync(dto.Id);
        await address.EnsureNotNullAsync(id: dto.Id);

        _mapper.Map(dto, address);
        await _repodsitory.UpdateAsync(address);
    }
}