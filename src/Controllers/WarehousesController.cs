using Microsoft.AspNetCore.Mvc;
using StockManagementSystem.Controllers.Requests;
using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class WarehousesController : ControllerBase
    {
        private readonly ILogger<WarehousesController> _logger;

        private readonly IWarehouseService _warehouseService;

        public WarehousesController(
            IWarehouseService warehouseService,
            ILogger<WarehousesController> logger)
        {
            _warehouseService = warehouseService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Warehouse>> Get()
        {
            return await _warehouseService.GetAllWarehouses();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> Get(int id)
        {
            var warehouse = await _warehouseService.GetWarehouseInfo(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<ActionResult<Warehouse>> Post([FromBody] CreateWarehouseRequest request)
        {
            try
            {
                Warehouse warehouse = await _warehouseService
                    .CreateNewWarehouse(request.MaximumStockLevel, request.AllowedMaterialType);

                return CreatedAtAction(nameof(Post), new { id = warehouse.Id }, warehouse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create warehouse request failed.");

                return UnprocessableEntity();
            }
        }

        [HttpPost("{id}/import")]
        public async Task<ActionResult> Import(int id, [FromBody] WarehouseImportRequest request)
        {
            try
            {
                await _warehouseService.ImportProduct(id, request.ProductId, request.Quantity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Warehouse immport request failed.");
                return UnprocessableEntity();
            }
        }

        [HttpPost("{id}/export")]
        public async Task<ActionResult> Export(int id, [FromBody] WarehouseImportRequest request)
        {
            try
            {
                await _warehouseService.ExportProduct(id, request.ProductId, request.Quantity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Warehouse export request failed.");
                return UnprocessableEntity();
            }
        }
    }
};
