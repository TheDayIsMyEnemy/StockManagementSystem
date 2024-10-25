namespace StockManagementSystem.Models
{
    public class Warehouse : BaseEntity
    {
        public Warehouse(int maximumStockAmount, MaterialType productType)
        {
            MaximumStockLevel = maximumStockAmount;
            AllowedMaterialType = productType;
        }

        public int MaximumStockLevel { get; private set; }

        public MaterialType AllowedMaterialType { get; private set; }

        public int CurrentStockLevel
            => Items.Count;

        public int FreeStockSpace
            => MaximumStockLevel - CurrentStockLevel;

        public List<WarehouseItem> Items { get; private set; } = new();

        public List<WarehouseItemLog> ItemsLog { get; private set; }

        public void Import(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.Id == productId);

            if (item == null)
            {
                Items.Add(new WarehouseItem(productId, quantity));
            }
            else
            {
                item.AddQuantity(quantity);
            }
        }

        public void Export(int productId, int quantity)
        {
            var item = Items.First(i => i.Id == productId);

            item.RemoveQuantity(quantity);

            if (item.Quantity == 0)
            {
                Items.Remove(item);
            }
        }

        public void AddLog(
            int productId,
            int previousQuantity,
            int currentQuantity,
            WarehouseOperationType operationType)
        {
            var log = new WarehouseItemLog(productId, previousQuantity, currentQuantity, operationType);
            ItemsLog.Add(log);
        }
    }
}