using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;
using StockManagementSystem.Services;

namespace StockManagementSystem.Factories
{
    public class WarehouseOperationFactory : IWarehouseOperationFactory
    {
        public IWarehouseOperationHandler CreateHandler(WarehouseOperationType operationType)
        {
            switch (operationType)
            {
                case WarehouseOperationType.Import:
                    return new WarehouseImportHandler();
                case WarehouseOperationType.Export:
                    return new WarehouseExportHandler();
                default:
                    throw new ArgumentException(nameof(operationType));
            }
        }
    }
}