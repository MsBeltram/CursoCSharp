using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
         public int CategoryId { get;set;}
        public Category Category {get;set;}
        public int SupplierId{get;set;}
        public Supplier Supplier {get;set;}

        public IEnumerable<InventoryMovement> InventoryMovements { get; set; }
    }
}