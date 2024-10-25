using StockManagementSystem.Models;
using StockManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StockManagementSystem.Data.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        protected readonly ApplicationDbContext Context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public async Task Add(T item)
        {
            await DbSet.AddAsync(item);
            await Context.SaveChangesAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await DbSet.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }
    }
}