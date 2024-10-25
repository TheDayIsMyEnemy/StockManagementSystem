using StockManagementSystem.Models;

namespace StockManagementSystem.Interfaces
{
    public interface IWarehouseOperationHandler
    {
        void HandleRequest(Warehouse warehouse, Product product, int quantity);
    }
}