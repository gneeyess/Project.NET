using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class EFUserRoleRepository : IRepository<UserRole>
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<UserRole> _dbSet;

        public EFUserRoleRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<UserRole>();
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<UserRole>> GetQueueAsync(int offset, int size)
        {
            var result = await _dbSet.AsNoTracking().Skip(offset * size).Take(size).ToListAsync();

            return result;
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
        public async Task UpdateAsync(UserRole userRole)
        {
            _dbSet.Update(userRole);

            await _context.SaveChangesAsync();
        }
        public async Task AddAsync(UserRole userRole)
        {
            await _dbSet.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }
    }
}