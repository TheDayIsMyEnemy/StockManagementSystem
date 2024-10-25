namespace StockManagementSystem.Models
{
    public class Product : BaseEntity
    {
        public Product(string name, MaterialType materialType)
        {
            Name = name;
            MaterialType = materialType;
        }

        public string Name { get; private set; }

        public MaterialType MaterialType { get; set; }

        public ProductDimension? Dimension { get; set; }
    }
}