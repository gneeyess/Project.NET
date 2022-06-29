using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class EFTransportRepository : IRepository<Transport>
    {
        private ApplicationContext _context;
        private DbSet<Transport> _dbSet;
        public EFTransportRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Transport>();
        }
        public async Task AddAsync(Transport transport)
        {
            await _dbSet.AddAsync(transport);
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

        public async Task<IEnumerable<Transport>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Transport> GetByIdAsync(int id)
        {
            var transport = await _dbSet.FindAsync(id);

            return transport;
        }

        public async Task UpdateAsync(Transport transport)
        {
            _dbSet.Update(transport);

            await _context.SaveChangesAsync();
        }
    }
}