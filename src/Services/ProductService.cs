using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productReopistory;

        private readonly IProductFactory _productFactory;

        public ProductService(
            IProductRepository repository,
            IProductFactory productFactory)
        {
            _productReopistory = repository;
            _productFactory = productFactory;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productReopistory.GetAll();
        }

        public async Task<Product> CreateNewProduct(string name, MaterialType materialType)
        {
            var product = _productFactory.Create(name, materialType);

            await _productReopistory.Add(product);

            return product;
        }
    }
}