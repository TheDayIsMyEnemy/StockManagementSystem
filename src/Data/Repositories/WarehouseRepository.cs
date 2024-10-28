using StockManagementSystem.Models;
using StockManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StockManagementSystem.Data.Repositories
{
    public class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(ApplicationDbContext context) : base(context)
        { }

        public override Task<List<Warehouse>> GetAll()
        {
            return Context
                .Warehouses
                .Include(w => w.Items)
                .ToListAsync();
        }

        public override Task<Warehouse?> GetById(int id)
        {
            return Context
                    .Warehouses
                    .Include(w => w.Items)
                    .Include(w => w.ItemsLog)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}