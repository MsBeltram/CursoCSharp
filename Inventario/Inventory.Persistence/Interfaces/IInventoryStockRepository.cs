using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Persistence.Repositories;

namespace Inventory.Persistence.Interfaces
{
    public interface IInventoryStockRepository : IBaseRepository<InventoryStock>
    {
        Task<InventoryStock> GetByIdAsync(int id);
        Task<bool> DeletAsync(int id);
        Task<bool> DeletAsync(InventoryStock entity);
    }
}