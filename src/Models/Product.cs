namespace StockManagementSystem.Models
{
    public class Product : BaseEntity
    {
        private Product() { }

        public Product(string name, MaterialType materialType)
        {
            Name = name;
            MaterialType = materialType;
        }

        public string Name { get; private set; } = null!;

        public MaterialType MaterialType { get; private set; }



        public List<WarehouseItem> WarehouseItems { get; private set; } = null!;
        public List<WarehouseItemLog> WarehouseItemLogs { get; private set; } = null!;

        // public ProductDimension? Dimension { get; set; }
    }
}