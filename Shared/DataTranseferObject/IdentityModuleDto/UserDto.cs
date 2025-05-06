using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranseferObject.IdentityModuleDto
{
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;

    }
}
