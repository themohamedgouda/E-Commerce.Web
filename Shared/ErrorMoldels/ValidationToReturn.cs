﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ErrorMoldels
{
    public class ValidationToReturn
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;
        public string Message { get; set; } = "Validation Errors";
        public IEnumerable<ValidationError> ValidationErrors { get; set; } = [];

    }
}
