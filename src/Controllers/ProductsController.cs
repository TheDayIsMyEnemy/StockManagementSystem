using Microsoft.AspNetCore.Mvc;
using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productService.GetAllProducts();
        }
    }
};
