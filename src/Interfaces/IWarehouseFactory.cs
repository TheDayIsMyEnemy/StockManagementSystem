using StockManagementSystem.Models;

namespace StockManagementSystem.Interfaces
{
    public interface IWarehouseFactory
    {
        Warehouse Create(int maximumStockLevel, MaterialType materialType);

    }
}