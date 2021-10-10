using CoreTShirtStore.Data;
using CoreTShirtStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTShirtStore.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected TShirtContext _context;
        public GenericRepository(TShirtContext context)
        {
            this._context = context;
        }

        public virtual async Task<IEnumerable<T>> GetFullListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual void Add(T entity)
        {
            _context.Add(entity);
        }

        public virtual bool CheckTShirtExists(int id)
        {
           return false; // Nedd to check what should be here in prep for the override.
        }

        public virtual async Task DeleteConfirmed(int id)
        {
            var tShirt = await _context.Set<T>().FindAsync(id);
            _context.Remove(tShirt);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> FindAsync(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetItemAsync(int? id)
        { 
          return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
