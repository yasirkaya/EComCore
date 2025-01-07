using EComCore.Domain.DTOs.UserDTO;

namespace EComCore.Domain.Services.Commands;

public interface IUserCommandService
{
    Task<UserDto> CreateUser(CreateUserDto createUserDto);
    Task<UserDto> UpdateUser(int id, UpdateUserDto updateUserDto);
    Task DeleteUser(int id);
}