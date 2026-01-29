using AssesmentTest.Interfaces;
using AssesmentTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssesmentTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _service.GetProductsAsync();
            return Ok(products);
        }
    }
}