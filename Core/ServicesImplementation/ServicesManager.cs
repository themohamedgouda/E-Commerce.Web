using AutoMapper;
using DomainLayer.Contracts;
using ServicesAbstractionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer
{
    public class ServicesManager(IUnitOfWork _unitOfWork , IMapper _mapper ) : IServicesManager
    {
        private readonly Lazy<IProductService> _LazyProductService = new Lazy<IProductService>(() => new ProductService(_unitOfWork , _mapper));

        public IProductService ProductService => _LazyProductService.Value;
    }
    
}
