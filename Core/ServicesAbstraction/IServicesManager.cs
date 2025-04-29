using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstractionLayer
{
    public interface IServicesManager
    {
        IProductService ProductService { get; }  
    }
}
