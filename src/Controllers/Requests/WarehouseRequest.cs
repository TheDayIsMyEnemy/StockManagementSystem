using System.ComponentModel.DataAnnotations;

namespace StockManagementSystem.Controllers.Requests
{
    public abstract class WarehouseRequest
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}