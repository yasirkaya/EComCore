using AutoMapper;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
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

    public async Task<AuthenticatedUserDto> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.GetByEmailAsync(loginDto.Email);
        await user.EnsureNotNullAsync(message: "Geçersiz Kimlik Bilgileri.");

        return _mapper.Map<AuthenticatedUserDto>(user);
    }

    public async Task<int> RegisterAsync(CreateUserDto createUserDto)
    {
        var user = _mapper.Map<User>(createUserDto);

        await _userRepository.AddAsync(user);
        return user.Id;
    }

}