namespace StockManagementSystem.Models
{
    public class ProductDimension : BaseEntity
    {
        public ProductDimension(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get; private set; }

        public double Height { get; private set; }

        public int ProductId { get; private set; }

        public Product Product { get; private set; } = null!;
    }
}