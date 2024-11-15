using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Entities;

namespace Inventory.Persistence.Interfaces
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        Task<Supplier> GetByIdAsync(int id);
        Task<bool> DeletAsync(int id);
        Task<bool> DeletAsync(Supplier entity);        
        Task<bool> DeleteAsync(Supplier supplierToDelete);
    }
}