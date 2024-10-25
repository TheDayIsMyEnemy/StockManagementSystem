using StockManagementSystem.Models;

namespace StockManagementSystem.Interfaces
{
    public interface IProductFactory
    {
        Product Create(string name, MaterialType materialType);
    }
}