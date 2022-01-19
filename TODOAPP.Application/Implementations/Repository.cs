using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODOAPP.Core.Interfaces;

namespace TODOAPP.Core.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IApplicationDbContext _context;

        public Repository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public List<T> Find(Func<T, bool> condition)
        {
            return _context.Set<T>().Where(condition).ToList();
        }

        public bool Exists(Func<T, bool> condition)
        {
            return _context.Set<T>().Any(condition);
        }

        public async Task AddAsync(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T obj)
        {
            _context.Set<T>().Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await this.GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}