using DomainLayer.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer.Specifications.OrderModuleSpecifications
{
    class OrderSpecification : BaseSpecifications<Order, Guid>
    {
        public OrderSpecification(string Email) : base(O => O.UserEmail == Email)
        {
            AddInclude(x => x.DelivaryMethod);
            AddInclude(x => x.Items);
            AddOrderByDescending(x => x.OrderDate);

        }
        public OrderSpecification(Guid id) : base(O => O.Id == id)
        {
            AddInclude(x => x.DelivaryMethod);
            AddInclude(x => x.Items);
        }  

    }
    
}
