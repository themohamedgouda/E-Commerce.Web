using Microsoft.Extensions.DependencyInjection;
using ServicesAbstractionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer.Specifications
{
    public static class ApplicationServicesRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
        {
           
            Services.AddAutoMapper(typeof(ServicesImplementationLayer.AssemblyReference).Assembly);
            Services.AddScoped<IServicesManager, ServicesManager>();
            return Services;

        }
    }
}
