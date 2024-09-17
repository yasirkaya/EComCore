using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Entities;

namespace EComCore.Domain.Services.Commands;

public interface IUserCommandService
{
    Task<int> RegisterAsync(CreateUserDto createUserDto);
    Task<AuthenticatedUserDto> LoginAsync(LoginDto loginDto);
    Task DeleteUserAsync(DeleteUserDto dto);
}