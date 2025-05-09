﻿using Shared.DataTranseferObject.IdentityModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstractionLayer
{
    public interface IAuthenticationServices
    {
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<bool> CheckEmailAsync(string email);
        Task<AdderessDto> GetCurrentUserAdderessAsync(string email);
        Task<AdderessDto> UpdatedCurrentUserAdderessAsync(string email,AdderessDto adderessDto);
        Task<UserDto> GetCurrentUserAsync(string email);



    }
}