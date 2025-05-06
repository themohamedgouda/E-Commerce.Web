﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Exceptions
{
    public class OrderNotFoundException(Guid id) : NotFoundExcpetion($"Order with id {id} not found")
    {
    }
}
