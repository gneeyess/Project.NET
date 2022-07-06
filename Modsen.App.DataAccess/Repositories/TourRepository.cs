using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;

namespace Modsen.App.DataAccess.Repositories
{
    public class TourRepository : IRepository<Tour>
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Tour> _dbSet;

        public TourRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Tour>();
        }

        public async Task<Tour> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Tour>> GetQueueAsync(int offset, int size)
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
        public async Task UpdateAsync(Tour tour)
        {
            _dbSet.Update(tour);

            await _context.SaveChangesAsync();
        }
        public async Task AddAsync(Tour tour)
        {
            await _dbSet.AddAsync(tour);
            await _context.SaveChangesAsync();
        }
    }
}