using StockManagementSystem.Models;

namespace StockManagementSystem.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> CreateNewProduct(string name, MaterialType materialType);
    }
}