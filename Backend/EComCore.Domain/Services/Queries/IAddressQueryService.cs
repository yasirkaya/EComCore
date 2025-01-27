using EComCore.Domain.DTOs.AddressDTO;

namespace EComCore.Domain.Services.Queries;

public interface IAddressQueryService
{
    Task<IEnumerable<AddressDto>> GetAllAsync();
    Task<AddressDto> GetByIdAsync(int id);
    Task<IEnumerable<AddressDto>> GetByUserIdAsync(int userId);
}