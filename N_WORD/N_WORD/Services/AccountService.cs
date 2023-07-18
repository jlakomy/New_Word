using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using N_WORD.Entities;
using N_WORD.Exceptions;
using N_WORD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N_WORD.Services
{
    public interface IAccountService
    {
        string GenerateJwt(LoginDto dto);
        void RegisterUser(RegisterUserDto dto);
    }
    public class AccountService: IAccountService
    {
        private N_WordDbContext _dbContext;
        private IPasswordHasher<User> _passwordhasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(N_WordDbContext dbcontext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbcontext;
            _passwordhasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);

            if (user == null)
            {
                throw new BadRequestException("Invalid email or password");
            }

            var result = _passwordhasher.VerifyHashedPassword(user, user.PassowrdHash, dto.Password);
            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid email or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd"))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer,
                claims, expires: expires, signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                Username = dto.Username,
                DateOfBirth = dto.DateOfBirth,
                RoleId = dto.RoleId
            };

            var hashedPassword = _passwordhasher.HashPassword(newUser, dto.Password);
            newUser.PassowrdHash = hashedPassword;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}
