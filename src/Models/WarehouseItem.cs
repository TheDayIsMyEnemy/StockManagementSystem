namespace StockManagementSystem.Models
{
    public class WarehouseItem : BaseEntity
    {
        public WarehouseItem(int productId, int quantity)
        {
            ProductId = productId;
            SetQuantity(quantity);
        }

        public int ProductId { get; private set; }

        public int Quantity { get; private set; }

        public int WarehouseId { get; private set; }

        public void AddQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            Quantity += quantity;
        }

        public void RemoveQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            if (Quantity < quantity)
            {
                throw new Exception("Invalid quantity");
            }

            Quantity -= quantity;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            Quantity = quantity;
        }
    }
}