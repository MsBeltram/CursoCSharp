

using Inventory.Entities;
using Inventory.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly AuthContext _context;

        public AuthRepository(AuthContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if(user == null)
            throw new InvalidOperationException("User not found."); // Or return a default user, etc.
            

            if(!VerifyPasswordHash(password,user.PasswordSalt,user.PasswordHash))
            throw new InvalidOperationException("User not found."); // Or return a default user, etc.

            return user;
        }
         private bool VerifyPasswordHash (string password,  byte[] passwordSalt,  byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA3_512(passwordSalt))
            {
               var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

               for(int i =0; i<computeHash.Length; i++)
               {
                if(computeHash[i] != passwordHash[i])
                    return false;
                           
               }
            }
             return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash(password, out passwordSalt, out passwordHash);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExist(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if(user != null)
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA3_512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}