using StockManagementSystem.Models;

namespace StockManagementSystem.Interfaces
{
    public interface IWarehouseOperationFactory
    {
        IWarehouseOperationHandler CreateHandler(WarehouseOperationType operationType);
    }
}