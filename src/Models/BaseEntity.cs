using System.ComponentModel.DataAnnotations;

namespace StockManagementSystem.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
    }
}