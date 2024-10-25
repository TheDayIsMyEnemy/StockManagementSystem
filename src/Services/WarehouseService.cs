using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouserepository;

        private readonly IProductRepository _productRepository;

        private readonly IWarehouseOperationFactory _warehouseoperationfactory;

        public WarehouseService(
            IWarehouseRepository warehouseRepository,
            IProductRepository productRepository,
            IWarehouseOperationFactory warehouseOperationFactory)
        {
            _warehouserepository = warehouseRepository;
            _productRepository = productRepository;
            _warehouseoperationfactory = warehouseOperationFactory;
        }

        public async Task ImportProduct(int warehouseId, int productId, int quantity)
        {
            var warehouse = await _warehouserepository.GetById(warehouseId);

            ArgumentNullException.ThrowIfNull(warehouse, nameof(warehouseId));

            var product = await _productRepository.GetById(productId);

            ArgumentNullException.ThrowIfNull(product, nameof(productId));

            var operationHandler = _warehouseoperationfactory.CreateHandler(WarehouseOperationType.Import);

            operationHandler.HandleRequest(warehouse, product, quantity);
        }

        public async Task ExportProduct(int warehouseId, int productId, int quantity)
        {
            var warehouse = await _warehouserepository.GetById(warehouseId);

            ArgumentNullException.ThrowIfNull(warehouse, nameof(warehouseId));

            var product = await _productRepository.GetById(productId);

            ArgumentNullException.ThrowIfNull(product, nameof(productId));

            var operationHandler = _warehouseoperationfactory.CreateHandler(WarehouseOperationType.Export);

            operationHandler.HandleRequest(warehouse, product, quantity);
        }
    }
}