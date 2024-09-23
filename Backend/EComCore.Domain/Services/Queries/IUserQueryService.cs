using EComCore.Domain.DTOs.AuthDTO;
using EComCore.Domain.DTOs.UserDTO;

namespace EComCore.Domain.Services.Queries;

public interface IUserQueryService
{
    Task<UserDetailsDto> GetByEmailAsync(string email);
    Task<IEnumerable<UserDetailsDto>> GetAllActiveUsersAsync();
    Task<UserDetailsDto> GetByIdActiveAsync(int id);
    Task<bool> IsExistsAsync(int id);
    Task<UserDetailsDto> GetByRefreshTokenAsync(string refreshToken);
}