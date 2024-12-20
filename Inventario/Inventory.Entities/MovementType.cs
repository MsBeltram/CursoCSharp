using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class MovementType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool IsIncoming { get; set; }
        public bool IsOutging { get; set; }
        public bool IsInternalTransfer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public IEnumerable<InventoryMovement> InventoryMovements { get; set; }
    }
}