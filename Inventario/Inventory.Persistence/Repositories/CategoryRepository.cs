using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category> , ICategoryRepository
    {
        public CategoryRepository(DataContext context): base(context)
        {
            
        }

        public Task<bool> DeletAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Category categoryToDelete)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Category categoryToUpdate)
        {
            throw new NotImplementedException();
        }

        Task<Category> ICategoryRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}