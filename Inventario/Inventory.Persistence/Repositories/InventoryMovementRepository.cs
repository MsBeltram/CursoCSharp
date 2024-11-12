using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Entities;

namespace Inventory.Persistence.Repositories
{
    public class InventoryMovementRepository: BaseRepository<InventoryMovement>, IInventoryMovementRepository
    {
           public InventoryMovementRepository(DataContext context): base(context)
        {
         
    }
    }
}