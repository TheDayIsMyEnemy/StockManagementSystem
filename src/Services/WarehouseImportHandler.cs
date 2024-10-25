using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Services
{
    public class WarehouseImportHandler : IWarehouseOperationHandler
    {
        public void HandleRequest(Warehouse warehouse, Product product, int quantity)
        {
            if (warehouse.AllowedMaterialType != product.MaterialType)
            {
                throw new Exception("Wrong material type");
            }

            if (warehouse.FreeStockSpace < quantity)
            {
                throw new Exception("Not enough storage space");
            }

            int previousQuantity
                = warehouse.Items.FirstOrDefault(i => i.Id == product.Id)?.Quantity ?? 0;

            warehouse.Import(product.Id, quantity);

            warehouse.AddLog(product.Id, previousQuantity, quantity, WarehouseOperationType.Import);
        }
    }
}