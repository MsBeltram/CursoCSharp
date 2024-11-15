using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string Name { get; set; } = "";
        public int Phone { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }

        //Properties for authentication and validation
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}