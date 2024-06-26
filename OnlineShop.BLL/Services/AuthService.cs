using OnlineShop.BLL.Interfaces;
using OnlineShop.BLL.DTO.RequestDTO.UsersRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;
using OnlineShop.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace OnlineShop.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task<AuthResult> RegisterAsync(UserRegisterDTO model)
        {
            var existingUser = await _userRepository.GetByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { "Email is already in use." }
                };
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email
            };

            user.Password = _passwordHasher.HashPassword(user, model.Password);

            await _userRepository.AddAsync(user);

            return new AuthResult
            {
                Success = true
            };
        }

        public async Task<AuthResult> LoginAsync(UserLoginDTO model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email);
            if (user == null)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { "User does not exist." }
                };
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { "Invalid password." }
                };
            }

            var token = GenerateJwtToken(user);

            return new AuthResult
            {
                Success = true,
                Token = token
            };
        }

        private string GenerateJwtToken(User user)
{
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_configuration["JwtConfig:Secret"]);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim("id", user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("role", "user")  // Default role is user
        }),
        Expires = DateTime.UtcNow.AddHours(6),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
}

    }
}
