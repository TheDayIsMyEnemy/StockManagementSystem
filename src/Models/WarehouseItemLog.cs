namespace StockManagementSystem.Models
{
    public class WarehouseItemLog : BaseEntity
    {
        public WarehouseItemLog(
            int productId,
            int previousQuantity,
            int currentQuantity,
            WarehouseOperationType operationType)
        {
            ProductId = productId;
            PreviousQuantity = previousQuantity;
            CurrentQuantity = currentQuantity;
            OperationType = operationType;
            CreatedAtUtc = DateTime.UtcNow;
        }

        public int WarehouseId { get; private set; }

        public int ProductId { get; private set; }

        public int PreviousQuantity { get; private set; }

        public int CurrentQuantity { get; private set; }

        public WarehouseOperationType OperationType { get; private set; }

        public DateTime CreatedAtUtc { get; private set; }
    }
}