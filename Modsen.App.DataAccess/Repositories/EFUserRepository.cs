using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class EFUserRepository : IRepository<User>
    {
        private ApplicationContext _context;
        private DbSet<User> _dbSet;
        public EFUserRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }
        public async Task AddAsync(User user)
        {
            await _dbSet.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _dbSet.FindAsync(id);

            if (item != null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _dbSet.FindAsync(id);

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _dbSet.Update(user);

            await _context.SaveChangesAsync();
        }
    }
}