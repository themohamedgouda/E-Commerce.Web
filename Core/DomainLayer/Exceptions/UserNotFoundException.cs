﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Exceptions
{
    public sealed class UserNotFoundException(string Email) : NotFoundExcpetion($"User With Email {Email} Is not Found")
    {
       
    }
}
