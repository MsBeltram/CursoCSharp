using Inventory.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable
    where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> AddAll(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeletAsync(int id)
        {
           bool salida = false;
            var item = await _dbSet.FindAsync(id);
            if(item != null){
                _context.Remove(item);
                await _context.SaveChangesAsync();
                salida= true;
            }

            return salida;
        }

        public async Task<bool> DeletAsync(T entity)
           {
             _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var item = await _dbSet.ToListAsync();
            return item;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var item = await _dbSet.FindAsync(id);
            return item;
        }

        public async Task<bool> UpdateAsync(int id, T entity)
        {
            bool salida = false;
            var item = await _dbSet.FindAsync(id);
            if(item != null){
                _context.Update(item);
                await _context.SaveChangesAsync();
                salida= true;
            }

            return salida;
        }
    }
}