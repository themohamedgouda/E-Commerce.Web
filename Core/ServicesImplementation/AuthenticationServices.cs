using DomainLayer.Exceptions;
using DomainLayer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using ServicesAbstractionLayer;
using Shared.DataTranseferObject.IdentityModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer
{
    public class AuthenticationServices(UserManager<ApplicationUser> _userManager) : IAuthenticationServices
    {
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email) ?? throw new UserNotFoundException(loginDto.Email);
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
            {
                throw new UnauthorizedException();
            }
            var token = CreateTokenAsync(user);
            return new UserDto
            {
                Email = user.Email,
                Token = token,
                DisplayName = user.DisplayName
            };
        }
        public async  Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                DisplayName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                return new UserDto
                {
                    Email = user.Email,
                    Token = CreateTokenAsync(user),
                    DisplayName = user.DisplayName
                };
            }
           var errors = result.Errors.Select(e => e.Description).ToList();
            throw new BadRequestException(errors);

        }
        private static string CreateTokenAsync(ApplicationUser user)
        {
            // Here you would create a JWT token using your preferred library
            // For example, using System.IdentityModel.Tokens.Jwt
            // This is just a placeholder implementation
            return "GeneratedTokenForUser"; // Replace with actual token generation logic

        }

    }
}
