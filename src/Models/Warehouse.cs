namespace StockManagementSystem.Models
{
    public class Warehouse : BaseEntity
    {
        private Warehouse() { }

        public Warehouse(int maximumStockLevel, MaterialType allowedMaterialType)
        {
            MaximumStockLevel = maximumStockLevel;
            AllowedMaterialType = allowedMaterialType;
        }

        public int MaximumStockLevel { get; private set; }

        public MaterialType AllowedMaterialType { get; private set; }

        public int CurrentStockLevel
            => Items.Sum(i => i.Quantity);

        public int FreeStockSpace
            => MaximumStockLevel - CurrentStockLevel;

        public bool HasFreeSpace
            => FreeStockSpace > 0;

        public List<WarehouseItem> Items { get; private set; } = new();

        public List<WarehouseItemLog> ItemsLog { get; private set; } = new();

        public void Import(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);

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
            var item = Items.First(i => i.ProductId == productId);

            item.RemoveQuantity(quantity);

            if (item.Quantity == 0)
            {
                Items.Remove(item);
            }
        }

        public void AddWarehouseItemLog(
            int productId,
            int previousQuantity,
            int currentQuantity,
            WarehouseOperationType operationType)
        {
            var log = new WarehouseItemLog(
                productId,
                previousQuantity,
                currentQuantity,
                operationType);

            ItemsLog.Add(log);
        }
    }
}