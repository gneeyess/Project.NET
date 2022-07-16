using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class TourTypeRepository : ITourTypeRepository, IRepository<TourType>
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TourType> _dbSet;
        //1
        public TourTypeRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TourType>();
        }
        //2
        public async Task<TourType> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        //3
        public async Task<IEnumerable<TourType>> GetQueueAsync(int offset, int size)
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
        public async Task UpdateAsync(TourType tourType)
        {
            _dbSet.Update(tourType);

            await _context.SaveChangesAsync();
        }
        //6
        public async Task AddAsync(TourType tourType)
        {
            await _dbSet.AddAsync(tourType);
            await _context.SaveChangesAsync();
        }
        public async Task<TourType> GetByNameWithTrackingAsync(string name)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Name == name);

            return result;
        }

    }
}