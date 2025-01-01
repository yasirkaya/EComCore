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
    private readonly IEmailService _emailService;
    private readonly IUserRoleRepository _userRoleRepository;

    public UserCommandService(
        IUserRepository userRepository,
        IUserRoleRepository userRoleRepository,
        IMapper mapper,
        IJwtService jwtService,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
        _jwtService = jwtService;
        _emailService = emailService;
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

        var authToken = await _jwtService.GenerateTokenAsync(loginDto.Email);

        authUser.Token = authToken.Token;
        authUser.RefreshToken = authToken.RefreshToken;

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

        var userRole = new UserRole
        {
            UserId = user.Id,
            RoleId = 6  // Customer
        };

        await _userRoleRepository.AddAsync(userRole);

        return user.Id;
    }

    public async Task LogoutAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        await user.EnsureNotNullAsync(message: "Geçersiz Kimlik Bilgileri.");

        user.RefreshToken = null;
        await _userRepository.UpdateAsync(user);
    }

    public async Task VerifyEmailAsync(string email, string token)
    {
        var user = await _userRepository.GetByEmailVerificationTokenAsync(token);
        await user.EnsureNotNullAsync(message: "Geçersiz doğrulama token'ı.");

        if (user.Email != email)
        {
            throw new Exception("Email adresi token ile eşleşmiyor.");
        }

        user.IsEmailVerified = true;
        user.EmailVerificationToken = null;
        await _userRepository.UpdateAsync(user);
    }

    public async Task ForgotPasswordAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        await user.EnsureNotNullAsync(message: "Bu email adresi ile kayıtlı kullanıcı bulunamadı.");

        string resetToken = Guid.NewGuid().ToString();
        user.PasswordResetToken = resetToken;
        user.PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(24);

        await _userRepository.UpdateAsync(user);

        // Email gönderme işlemi
        await _emailService.SendPasswordResetEmailAsync(email, resetToken);
    }

    public async Task ResetPasswordAsync(string email, string token, string newPassword)
    {
        var user = await _userRepository.GetByPasswordResetTokenAsync(token);
        await user.EnsureNotNullAsync(message: "Geçersiz veya süresi dolmuş token.");

        if (user.Email != email)
        {
            throw new Exception("Email adresi token ile eşleşmiyor.");
        }

        user.PasswordHash = PasswordHashExtensions.HashPassword(newPassword);
        user.PasswordResetToken = null;
        user.PasswordResetTokenExpiry = null;

        await _userRepository.UpdateAsync(user);
    }
}