using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstractionLayer
{
    public interface IServicesManager
    {
       public IProductService ProductService { get; }  
       public IBasketServices BasketServices { get; }  
       public IAuthenticationServices AuthenticationService { get; }  
       public IOrderServices OrderServices { get; }  
    }
}
