using StockManagementSystem.Models;
using StockManagementSystem.Interfaces;

namespace StockManagementSystem.Data.Repositories
{
    public class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}