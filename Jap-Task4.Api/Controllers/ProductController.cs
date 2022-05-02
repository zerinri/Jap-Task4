using Jap_Task4.Core.Dtos.Products;
using Jap_Task4.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jap_Task4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            if (!_productService.ProductExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _productService.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto newProduct)
        {
            if (newProduct == null)
                return BadRequest(ModelState);

            return Ok(await _productService.AddProduct(newProduct));
        }
    }
}