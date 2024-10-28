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

            var existingItem = warehouse.Items.FirstOrDefault(i => i.ProductId == product.Id);

            int previousQuantity = existingItem?.Quantity ?? 0;

            warehouse.Import(product.Id, quantity);

            int currentQuantity = existingItem?.Quantity ?? quantity;

            warehouse.AddWarehouseItemLog(product.Id, previousQuantity, currentQuantity, WarehouseOperationType.Import);
        }
    }
}