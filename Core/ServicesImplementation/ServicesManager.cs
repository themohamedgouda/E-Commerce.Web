using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ServicesAbstractionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer
{
    public class ServicesManager(IUnitOfWork _unitOfWork, IMapper _mapper, IBasketRepository _basketRepository , UserManager<ApplicationUser> _userManager , IConfiguration _configuration) : IServicesManager
    {
        private readonly Lazy<IProductService> _LazyProductService = new Lazy<IProductService>(() => new ProductService(_unitOfWork , _mapper));
        private readonly Lazy<IBasketServices> _LazyBasketServices = new Lazy<IBasketServices>(() => new BasketServices(_basketRepository, _mapper));
        private readonly Lazy<IAuthenticationServices> _LazyAuthenticationServices = new Lazy<IAuthenticationServices>(() => new AuthenticationServices(_userManager, _configuration));
        public IProductService ProductService => _LazyProductService.Value;
        public IBasketServices BasketServices => _LazyBasketServices.Value;
        public IAuthenticationServices AuthenticationService => _LazyAuthenticationServices.Value;
    }
    
}
