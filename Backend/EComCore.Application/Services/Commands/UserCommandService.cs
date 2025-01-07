using AutoMapper;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands;

public class UserCommandService : IUserCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserCommandService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateUser(CreateUserDto createUserDto)
    {
        var user = _mapper.Map<User>(createUserDto);
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new Exception($"User with id {id} not found");

        _mapper.Map(updateUserDto, user);
        await _userRepository.SaveChangesAsync();
        return _mapper.Map<UserDto>(user);
    }

    public async Task DeleteUser(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new Exception($"User with id {id} not found");

        await _userRepository.DeleteAsync(user);
        await _userRepository.SaveChangesAsync();
    }
}