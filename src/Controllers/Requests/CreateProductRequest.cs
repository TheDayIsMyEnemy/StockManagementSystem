using System.ComponentModel.DataAnnotations;
using StockManagementSystem.Models;

namespace StockManagementSystem.Controllers.Requests
{
    public class CreateProductRequest
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public MaterialType MaterialType { get; set; }
    }
}