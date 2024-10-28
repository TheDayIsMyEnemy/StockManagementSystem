
using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Factories
{
    public class WarehouseFactory : IWarehouseFactory
    {
        public Warehouse Create(int maximumStockLevel, MaterialType materialType)
        {
            return new Warehouse(maximumStockLevel, materialType);
        }
    }

}