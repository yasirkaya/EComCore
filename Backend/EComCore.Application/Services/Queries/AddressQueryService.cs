using AutoMapper;
using EComCore.Domain.DTOs.AddressDTO;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.Services.Queries;

public class AddressQueryService : IAddressQueryService
{
    private readonly IAddressRepository _repository;
    private readonly IMapper _mapper;
    public AddressQueryService(IAddressRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AddressDto>> GetAllAsync()
    {
        var addresses = _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<AddressDto>>(addresses);
    }

    public async Task<AddressDto> GetByIdAsync(int id)
    {
        var address = await _repository.GetByIdAsync(id);
        await address.EnsureNotNullAsync(id: id);

        return _mapper.Map<AddressDto>(address);
    }

    public async Task<IEnumerable<AddressDto>> GetByUserIdAsync(int userId)
    {
        var addresses = await _repository.GetByUserIdAsync(userId);
        await addresses.EnsureNotNullOrEmptyAsync(message: "No addresses found for this user");

        return _mapper.Map<IEnumerable<AddressDto>>(addresses);
    }
}