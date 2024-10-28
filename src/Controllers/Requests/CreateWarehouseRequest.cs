using System.ComponentModel.DataAnnotations;
using StockManagementSystem.Models;

namespace StockManagementSystem.Controllers.Requests
{
    public class CreateWarehouseRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int MaximumStockLevel { get; set; }

        [Required]
        public MaterialType AllowedMaterialType { get; set; }
    }
}