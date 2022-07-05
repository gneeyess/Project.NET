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
    public class EFTourTypeRepository : IRepository<TourType>
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TourType> _dbSet;

        public EFTourTypeRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TourType>();
        }

        public async Task<TourType> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TourType>> GetQueueAsync(int offset, int size)
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