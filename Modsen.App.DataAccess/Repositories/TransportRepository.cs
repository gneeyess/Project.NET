using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Linq;


namespace Modsen.App.DataAccess.Repositories
{
    public class TransportRepository : ITransportRepository, IRepository<Transport>
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Transport> _dbSet;
        //1
        public TransportRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Transport>();
        }
        //2
        public async Task<Transport> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        //3
        public async Task<IEnumerable<Transport>> GetQueueAsync(int offset, int size)
        {
            var result = await _dbSet.AsNoTracking().Skip(offset * size).Take(size).ToListAsync();

            return result;
        }
        //4
        public async Task DeleteAsync(int id)
        {
            var item = await _dbSet.FindAsync(id);

            if (item != null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
        //5
        public async Task UpdateAsync(Transport transport)
        {
            _dbSet.Update(transport);

            await _context.SaveChangesAsync();
        }
        //6
        public async Task AddAsync(Transport TRANSport)
        {
            await _dbSet.AddAsync(TRANSport);
            await _context.SaveChangesAsync();
        }

        public async Task<Transport> GetByNameWithTrackingAsync(string name)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Name == name);

            return result;
        }
    }
}