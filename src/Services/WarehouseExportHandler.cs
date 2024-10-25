using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Services
{
    public class WarehouseExportHandler : IWarehouseOperationHandler
    {
        public void HandleRequest(Warehouse warehouse, Product product, int quantity)
        {
            var item = warehouse.Items.FirstOrDefault(i => i.Id == product.Id);
            if (item == null)
            {
                throw new Exception("Product does not exist");
            }

            int previousQuantity = item.Quantity;

            warehouse.Export(product.Id, quantity);

            int currentQuantity = item.Quantity;

            warehouse.AddLog(product.Id, previousQuantity, currentQuantity, WarehouseOperationType.Export);
        }
    }
}