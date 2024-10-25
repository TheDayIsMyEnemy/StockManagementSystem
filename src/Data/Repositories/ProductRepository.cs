using StockManagementSystem.Models;
using StockManagementSystem.Interfaces;

namespace StockManagementSystem.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}