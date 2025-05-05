using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Exceptions
{
    public sealed class AdderessNotFoundException(string email) : NotFoundExcpetion($"Address not found for user with email: {email}")
    {
    }

}
