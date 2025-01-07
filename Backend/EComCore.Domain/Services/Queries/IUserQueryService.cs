using EComCore.Domain.DTOs.UserDTO;

namespace EComCore.Domain.Services.Queries;

public interface IUserQueryService
{
    Task<List<UserDto>> GetAllUsers();
    Task<UserDto> GetUserById(int id);
    Task<UserDto> GetUserByEmail(string email);
}