using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventary.DTOs.Category
{
    public class CategoryToListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}