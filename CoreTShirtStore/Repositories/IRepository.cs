using CoreTShirtStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTShirtStore.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetFullListAsync();

        Task<T> GetItemAsync(int? id);

        Task<T> FindAsync(int? id);

        void Add(T entity);

        void Update(T entity);

        Task DeleteConfirmed(int id);

        Task SaveChangesAsync();

        bool CheckTShirtExists(int id);
    }
}
