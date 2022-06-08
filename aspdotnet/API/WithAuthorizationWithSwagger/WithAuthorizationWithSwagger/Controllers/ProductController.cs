using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WithAuthorizationWithSwagger.Data;

namespace WithAuthorizationWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet,Authorize]
        public IActionResult GetAllProducts()
        {
            var products = ProductStore.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = ProductStore.GetProduct(id);

            if(product == null)
                return BadRequest();

            return Ok(product);
        }
    }
}
