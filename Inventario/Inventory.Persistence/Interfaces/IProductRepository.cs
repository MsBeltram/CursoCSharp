using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Entities;

namespace Inventory.Persistence.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByIdAsync(int id);
        Task<bool> DeletAsync(int id);
        Task<bool> DeletAsync(Product entity);
    }
}