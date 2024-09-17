using AutoMapper;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;
using EComCore.Domain.Services.Shared;

namespace EComCore.Application.Services.Commands;

public class UserCommandService : IUserCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;
    public UserCommandService(IUserRepository userRepository, IMapper mapper, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task DeleteUserAsync(DeleteUserDto dto)
    {
        var user = await _userRepository.GetByIdAsync(dto.Id);
        await user.EnsureNotNullAsync(id: dto.Id);

        user.Username = "Deleted";
        user.Email = "Deleted";
        user.IsActive = false;
        user.UpdatedAt = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);
    }

    public async Task<AuthenticatedUserDto> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.GetByEmailAsync(loginDto.Email);
        await user.EnsureNotNullAsync(message: "Geçersiz Kimlik Bilgileri.");

        if (!PasswordHashExtensions.VerifyPassword(loginDto.Password, user.PasswordHash))
        {
            throw new Exception("Hatalı Şifre");
        }

        var authUser = _mapper.Map<AuthenticatedUserDto>(user);

        authUser.Token = _jwtService.GenerateToken(loginDto);

        return authUser;
    }

    public async Task<int> RegisterAsync(CreateUserDto createUserDto)
    {

        var existingUser = await _userRepository.GetByEmailAsync(createUserDto.Email);
        if (existingUser != null)
        {
            throw new Exception("This email is already registered.");
        }

        var user = _mapper.Map<User>(createUserDto);

        await _userRepository.AddAsync(user);

        //Varsayılan rol eklenecek.

        return user.Id;
    }

}