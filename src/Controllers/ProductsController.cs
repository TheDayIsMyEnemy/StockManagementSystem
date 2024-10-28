using Microsoft.AspNetCore.Mvc;
using StockManagementSystem.Controllers.Requests;
using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        private readonly IProductService _productService;

        public ProductsController(
            IProductService productService,
            ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.GetAllProducts();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] CreateProductRequest request)
        {
            Product product = await _productService
                .CreateNewProduct(request.Name, request.MaterialType);

            return CreatedAtAction(nameof(Post), new { id = product.Id }, product);
        }
    }
};
