using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventary.DTOs.Category
{
    public class CategoryToEditDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string?  Name { get; set; }
    }
}