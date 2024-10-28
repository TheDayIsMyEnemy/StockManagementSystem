using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Services
{
    public class WarehouseExportHandler : IWarehouseOperationHandler
    {
        public void HandleRequest(Warehouse warehouse, Product product, int quantity)
        {
            var existingItem = warehouse.Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (existingItem == null)
            {
                throw new Exception("Product does not exist");
            }

            int previousQuantity = existingItem?.Quantity ?? 0;

            warehouse.Export(product.Id, quantity);

            int currentQuantity = existingItem!.Quantity;

            warehouse.AddWarehouseItemLog(product.Id, previousQuantity, currentQuantity, WarehouseOperationType.Export);
        }
    }
}