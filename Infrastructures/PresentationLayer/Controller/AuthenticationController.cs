using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstractionLayer;
using Shared.DataTranseferObject.IdentityModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controller
{
 
    public class AuthenticationController(IServicesManager servicesManager) : APIBaseController
    {
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var result = await servicesManager.AuthenticationService.LoginAsync(loginDto);
            return Ok(result);
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var result = await servicesManager.AuthenticationService.RegisterAsync(registerDto);
            return Ok(result);
        }
        [HttpGet("CheckEmail")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var result = await servicesManager.AuthenticationService.CheckEmailAsync(email);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var result = await servicesManager.AuthenticationService.GetCurrentUserAsync(email!);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("Address")]
        public async Task<ActionResult<AdderessDto>> GetCurrentUserAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var result = await servicesManager.AuthenticationService.GetCurrentUserAdderessAsync(email!);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("Orders")]
        public async Task<ActionResult<AdderessDto>> UpdateCurrentUserAddress(AdderessDto adderessDto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var result = await servicesManager.AuthenticationService.UpdatedCurrentUserAdderessAsync(email!, adderessDto);
            return Ok(result);

        }




    }
}
