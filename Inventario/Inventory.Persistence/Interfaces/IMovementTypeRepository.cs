using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Entities;

namespace Inventory.Persistence.Interfaces
{
    public interface IMovementTypeRepository : IBaseRepository<MovementType>
    {
        Task<MovementType> GetByIdAsync(int id);
        Task<bool> DeletAsync(int id);
        Task<bool> DeletAsync(MovementType entity);
        Task<bool> DeleteAsync(MovementType movementTypeToDelete);
    }
}