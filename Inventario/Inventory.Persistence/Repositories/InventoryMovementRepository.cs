using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Repositories
{
    public class InventoryMovementRepository: BaseRepository<InventoryMovement>, IInventoryMovementRepository
    {
        private readonly DataContext _context;
           public InventoryMovementRepository(DataContext context): base(context)
        {
            _context = context;
        }       

        public async Task<bool> DeleteAsync(int id)
        {
            var inventoryMovement = await _context.inventoryMovements.FindAsync(id);
            if (inventoryMovement == null)
            {
                return false;
            }

            _context.inventoryMovements.Remove(inventoryMovement);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}