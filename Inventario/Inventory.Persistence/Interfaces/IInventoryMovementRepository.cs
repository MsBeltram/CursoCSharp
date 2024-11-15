using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Persistence.Interfaces;

namespace Inventory.Persistence
{
    public interface IInventoryMovementRepository : IBaseRepository<InventoryMovement>
    {
        Task<InventoryMovement> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}