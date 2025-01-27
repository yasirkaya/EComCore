using EComCore.Domain.DTOs.AddressDTO;

namespace EComCore.Domain.Services.Commands
{
    public interface IAddressCommandService
    {
        Task<int> CreateAddressAsync(CreateAddressDto dto);
        Task UpdateAddressAsync(UpdateAddressDto dto);
        Task DeleteAddressAsync(DeleteAddressDto dto);
    }
}