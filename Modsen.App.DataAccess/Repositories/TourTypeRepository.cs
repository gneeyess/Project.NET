using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class TourTypeRepository : IRepository<TourType>
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TourType> _dbSet;

        public TourTypeRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TourType>();
        }

        public async Task<TourType> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TourType>> GetQueueAsync(int offset, int size)
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
        public async Task UpdateAsync(TourType tourType)
        {
            _dbSet.Update(tourType);

            await _context.SaveChangesAsync();
        }
        public async Task AddAsync(TourType tourType)
        {
            await _dbSet.AddAsync(tourType);
            await _context.SaveChangesAsync();
        }
    }
}