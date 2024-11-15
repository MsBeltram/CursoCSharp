using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Persistence.Repositories;

namespace Inventory.Persistence.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetByIdAsync(int id);
        Task<bool> DeletAsync(int id);
        Task<bool> DeletAsync(Category entity);
        Task<bool> DeleteAsync(Category categoryToDelete);
        Task<bool> UpdateAsync(int id, Category categoryToUpdate);
    }
}