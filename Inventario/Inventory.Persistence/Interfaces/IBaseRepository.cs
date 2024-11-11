using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Persistence.Interfaces
{
    public interface IBaseRepository<T>
    where   T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddAll(IEnumerable<T> entities);
        Task<bool> UpdateAsync (int id, T entity);
        Task<bool> DeletAsync(int id);
        Task<bool> DeletAsync(T entity);

    }
}