using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class APIBaseController : ControllerBase
    {

        protected string GetUserEmailFromToken()
        {
            return User.FindFirstValue(ClaimTypes.Email)!;
        }


    }
}
