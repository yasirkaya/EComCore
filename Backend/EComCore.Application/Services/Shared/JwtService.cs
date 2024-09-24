using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;
using EComCore.Domain.Services.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EComCore.Application.Services.Shared;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public JwtService(IConfiguration configuration, IUserRepository userRepository, IUserRoleRepository userRoleRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<AuthTokenDto> GenerateTokenAsync(string email)
    {
        var secretKey = _configuration["JwtSettings:Secret"];
        var issuer = _configuration["JwtSettings:Issuer"];
        var audience = _configuration["JwtSettings:Audience"];
        var expiration = int.Parse(_configuration["JwtSettings:ExpiryMinutes"]);

        var user = await _userRepository.GetByEmailAsync(email);
        await user.EnsureNotNullAsync(message: $"User with Email {email} not found");

        if (user.RefreshTokenExpiryTime > DateTime.UtcNow || user.RefreshTokenExpiryTime == null)
        {
            user.RefreshToken = await GenerateRefreshTokenAsync();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateAsync(user);
        }

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var roles = await _userRoleRepository.GetUserRolesAsync(user.Id);
        await roles.EnsureNotNullOrEmptyAsync(id: user.Id);

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expiration),
            signingCredentials: creds);

        return new AuthTokenDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            RefreshToken = user.RefreshToken,
        };
    }

    private async Task<string> GenerateRefreshTokenAsync()
    {
        var randomNumber = new byte[32];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }

        var refreshToken = Convert.ToBase64String(randomNumber);

        return await Task.FromResult(refreshToken);
    }
}