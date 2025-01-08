using AutoMapper;
using EComCore.Domain.DTOs.AuthDTO;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Auth;
using EComCore.Domain.Services.Shared;
using System;

namespace EComCore.Application.Services.Auth;

public class AuthCommandService : IAuthCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;
    private readonly IEmailService _emailService;

    public AuthCommandService(
        IUserRepository userRepository,
        IMapper mapper,
        IJwtService jwtService,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtService = jwtService;
        _emailService = emailService;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.GetByEmailAsync(loginDto.Email);
        if (user == null)
            throw new Exception("Geçersiz kimlik bilgileri");

        if (!VerifyPassword(loginDto.Password, user.PasswordHash))
            throw new Exception("Geçersiz kimlik bilgileri");

        var token = await _jwtService.GenerateTokenAsync(user.Email);
        user.RefreshToken = token.RefreshToken;
        await _userRepository.UpdateAsync(user);

        return new AuthResponseDto
        {
            Token = token.Token,
            RefreshToken = token.RefreshToken,
            User = _mapper.Map<UserDto>(user)
        };
    }

    public async Task LogoutAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı");

        user.RefreshToken = null;
        await _userRepository.UpdateAsync(user);
    }

    public async Task ForgotPasswordAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
            throw new Exception("Kullanıcı bulunamadı");

        var resetToken = Guid.NewGuid().ToString();
        user.PasswordResetToken = resetToken;
        user.PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(24);
        await _userRepository.UpdateAsync(user);

        await _emailService.SendPasswordResetEmailAsync(email, resetToken);
    }

    public async Task ResetPasswordAsync(string email, string token, string newPassword)
    {
        var user = await _userRepository.GetByPasswordResetTokenAsync(token);
        if (user == null || user.Email != email)
            throw new Exception("Geçersiz veya süresi dolmuş token");

        user.PasswordHash = HashPassword(newPassword);
        user.PasswordResetToken = null;
        user.PasswordResetTokenExpiry = null;
        await _userRepository.UpdateAsync(user);
    }

    public async Task VerifyEmailAsync(string email, string token)
    {
        var user = await _userRepository.GetByEmailVerificationTokenAsync(token);
        if (user == null || user.Email != email)
            throw new Exception("Geçersiz doğrulama token'ı");

        user.IsEmailVerified = true;
        user.EmailVerificationToken = null;
        await _userRepository.UpdateAsync(user);
    }

    private bool VerifyPassword(string password, string passwordHash)
    {
        // TODO: Implement password verification
        return true;
    }

    private string HashPassword(string password)
    {
        // TODO: Implement password hashing
        return password;
    }
}