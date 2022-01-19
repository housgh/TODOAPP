using System.Collections.Generic;
using System.Threading.Tasks;

namespace TODOAPP.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task AddAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(int id);
    }
}