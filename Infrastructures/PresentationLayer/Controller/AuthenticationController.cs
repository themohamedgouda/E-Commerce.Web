using Microsoft.AspNetCore.Mvc;
using ServicesAbstractionLayer;
using Shared.DataTranseferObject.IdentityModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}
