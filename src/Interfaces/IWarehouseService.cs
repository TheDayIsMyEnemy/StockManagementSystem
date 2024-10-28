using StockManagementSystem.Models;

namespace StockManagementSystem.Interfaces
{
    public interface IWarehouseService
    {
        Task<List<Warehouse>> GetAllWarehouses();

        Task<Warehouse> CreateNewWarehouse(int maximumStockLevel, MaterialType materialType);

        Task<Warehouse?> GetWarehouseInfo(int warehouseId);

        Task ImportProduct(int warehouseId, int productId, int quantity);

        Task ExportProduct(int warehouseId, int productId, int quantity);
    }
}