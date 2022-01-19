using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TODOAPP.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(int id);
        List<T> Find(Func<T, bool> condition);
        bool Exists(Func<T, bool> condition);
        Task AddAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(int id);
    }
}