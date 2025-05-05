using AutoMapper;
using DomainLayer.Exceptions;
using DomainLayer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServicesAbstractionLayer;
using Shared.DataTranseferObject.IdentityModuleDto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer
{
    public class AuthenticationServices(UserManager<ApplicationUser> _userManager ,IConfiguration _configuration , IMapper mapper) : IAuthenticationServices
    {
        public async Task<bool> CheckEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
           
            return user is null;
        }
            

        public async Task<AdderessDto> GetCurrentUserAdderessAsync(string email)
        {
            var user = await _userManager.Users.Include(U => U.Address)
                .FirstOrDefaultAsync(U => U.Email == email) ??  throw new UserNotFoundException(email); ;

            if(user.Address is not null)
                return mapper.Map<AdderessDto>(user.Address);
            throw new AdderessNotFoundException(email);
        }

        public async Task<UserDto> GetCurrentUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email) ?? throw new UserNotFoundException(email);
            return new UserDto()
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = await CreateTokenAsync(user),

            };


        }

        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email) ?? throw new UserNotFoundException(loginDto.Email);
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
            {
                throw new UnauthorizedException();
            }
            var token = await CreateTokenAsync(user);
            return new UserDto
            {
                Email = user.Email!,
                Token =  token,
                DisplayName = user.DisplayName
            };
        }
        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
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
                    Token = await CreateTokenAsync(user),
                    DisplayName = user.DisplayName
                };
            }
            var errors = result.Errors.Select(e => e.Description).ToList();
            throw new BadRequestException(errors);

        }

        public async Task<AdderessDto> UpdatedCurrentUserAdderessAsync(string email, AdderessDto adderessDto)
        {
            var user = await _userManager.Users.Include(U => U.Address)
                .FirstOrDefaultAsync(U => U.Email == email) ?? throw new UserNotFoundException(email); ;
            if (user.Address is not null)
            {
                user.Address.City = adderessDto.City;
                user.Address.Street = adderessDto.Street;
                user.Address.Country = adderessDto.Country;
                user.Address.FirstName = adderessDto.FirstName;
                user.Address.LastName = adderessDto.LastName;
            }
            else
            {
                user.Address =  mapper.Map<AdderessDto , Address>(adderessDto);


            }
            var result = await _userManager.UpdateAsync(user);
            await _userManager.UpdateAsync(user);
            return mapper.Map<AdderessDto>(user.Address);
        } 
        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var Cliams = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.UserName !),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var Roples = await _userManager.GetRolesAsync(user);
            foreach (var role in Roples)
            {
                Cliams.Add(new Claim(ClaimTypes.Role, role));
            }
            var SectetKey = _configuration.GetSection("JwdOptions")["SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SectetKey));
            var Credes = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _configuration.GetSection("JwdOptions")["Issuer"]
                , claims: Cliams
                , audience: _configuration.GetSection("JwdOptions")["Audience"]
                , expires: DateTime.Now.AddHours(1)
                , signingCredentials: Credes);
            return  new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}