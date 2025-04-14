using E_Commerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    #region API Controller Notes
    // 1- Automatic Model Validation
    // 2- Automatic Binding 
    // 3- Tell me the Format of Response
    // 4- Attribute Routing
    // 5- 
    #endregion
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id) {

            return new Product
            {
                Id = id
            };
        }
        [HttpGet]
        public ActionResult<Product> GetAllProduct()
        {

            return new Product
            {
                Id = 100
            };
        }
        [HttpPost]
        public ActionResult<Product> AddProduct()
        {

            return new Product
            {
                Id = 100
            };
        }
        [HttpPut]
        public ActionResult<Product> UpdateProduct()
        {

            return new Product
            {
                Id = 100
            };
        }
        [HttpDelete]
        public ActionResult<Product> DeleteProduct()
        {

            return new Product
            {
                Id = 100
            };
        }
    }
}
