using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Worklyn_backend.Api.DTOs.Auth;
using Worklyn_backend.Application.Interfaces;
using Worklyn_backend.Domain.Data;
using Worklyn_backend.Domain.Entities;

namespace Worklyn_backend.Application.Services.Auth
{
    public class AuthService
    {

        private readonly AppDbContext _dbContext;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(AppDbContext dbContext, ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthResponseDTO> RegisterAsync(RegisterDTO dto)
        {
            if (await _dbContext.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("User already exists");

            var user = new User
            {
                UserId = Guid.NewGuid(),
                Email = dto.Email,
                FullName = dto.FullName,
                PasswordHash = _passwordHasher.HashPassword(dto.Password),
                CompanyId = dto.CompanyId
            };


            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(user);
            user.RefreshTokens.Add(refreshToken);
            
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return new AuthResponseDTO
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token.Token,
                RefreshTokenExpiresAt = refreshToken.Token.ExpiresAt
            };
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginDTO dto)
        {
            var user = await _dbContext.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || !_passwordHasher.VerifyPassword(dto.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(user);


            _dbContext.RefreshTokens.Add(refreshToken);
            await _dbContext.SaveChangesAsync();

            return new AuthResponseDTO
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token.Token,
                RefreshTokenExpiresAt = refreshToken.Token.ExpiresAt
            };
        }

    }
}
