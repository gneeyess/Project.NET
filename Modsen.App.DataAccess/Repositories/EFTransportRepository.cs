using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class EFTransportRepository : IRepository<Transport>
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Transport> _dbSet;

        public EFTransportRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Transport>();
        }

        public async Task<Transport> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Transport>> GetQueueAsync(int offset, int size)
        {
            var result = await _dbSet.AsNoTracking().Skip(offset * size).Take(size).ToListAsync();

            return result;
        }
        public async Task DeleteAsync(Guid id)
        {
            var item = await _dbSet.FindAsync(id);

            if (item != null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(Transport transport)
        {
            _dbSet.Update(transport);

            await _context.SaveChangesAsync();
        }
        public async Task AddAsync(Transport transport)
        {
            await _dbSet.AddAsync(transport);
            await _context.SaveChangesAsync();
        }
    }
}