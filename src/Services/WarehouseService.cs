using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouserepository;

        private readonly IProductRepository _productRepository;

        private readonly IWarehouseFactory _warehouseFactory;

        private readonly IWarehouseOperationFactory _warehouseoperationfactory;

        public WarehouseService(
            IWarehouseRepository warehouseRepository,
            IProductRepository productRepository,
            IWarehouseFactory warehouseFactory,
            IWarehouseOperationFactory warehouseOperationFactory)
        {
            _warehouserepository = warehouseRepository;
            _productRepository = productRepository;
            _warehouseFactory = warehouseFactory;
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

            await _warehouserepository.Update(warehouse);
        }

        public async Task ExportProduct(int warehouseId, int productId, int quantity)
        {
            var warehouse = await _warehouserepository.GetById(warehouseId);
            ArgumentNullException.ThrowIfNull(warehouse, nameof(warehouseId));

            var product = await _productRepository.GetById(productId);
            ArgumentNullException.ThrowIfNull(product, nameof(productId));

            var operationHandler = _warehouseoperationfactory.CreateHandler(WarehouseOperationType.Export);
            operationHandler.HandleRequest(warehouse, product, quantity);

            await _warehouserepository.Update(warehouse);
        }

        public async Task<List<Warehouse>> GetAllWarehouses()
        {
            return await _warehouserepository.GetAll();
        }

        public async Task<Warehouse> CreateNewWarehouse(int maximumStockLevel, MaterialType materialType)
        {
            var warehouse = _warehouseFactory.Create(maximumStockLevel, materialType);

            await _warehouserepository.Add(warehouse);

            return warehouse;
        }

        public async Task<Warehouse?> GetWarehouseInfo(int warehouseId)
        {
            return await _warehouserepository.GetById(warehouseId);
        }
    }
}