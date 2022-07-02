using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class EFUserRoleRepository : IRepository<UserRole>
    {
        private ApplicationContext _context;
        private DbSet<UserRole> _dbSet;

        public EFUserRoleRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<UserRole>();
        }

        public async Task AddAsync(UserRole userRole)
        {
            await _dbSet.AddAsync(userRole);
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
        } //Этот метод одинаковый у 6ти классов Repository

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(UserRole userRole)
        {
            _dbSet.Update(userRole);

            await _context.SaveChangesAsync();
        }
    }
}