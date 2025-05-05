﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {

        public string DisplayName { get; set; } = string.Empty;
        public Address? Address { get; set; }


    }
}
