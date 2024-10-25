using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Factories
{
    public class ProductFactory : IProductFactory
    {
        public Product Create(string name, MaterialType materialType)
        {
            return new Product(name, materialType);
        }
    }
}