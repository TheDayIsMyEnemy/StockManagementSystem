using StockManagementSystem.Models;

namespace StockManagementSystem.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task Add(T item);

        Task<T?> GetById(int id);

        Task<List<T>> GetAll();
    }
}