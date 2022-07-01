using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class EFTourTypeRepository : IRepository<TourType>
    {
        private ApplicationContext _context;
        private DbSet<TourType> _dbSet;

        public EFTourTypeRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TourType>();
        }

        public async Task AddAsync(TourType tourType)
        {
            await _dbSet.AddAsync(tourType);
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

        public async Task<IEnumerable<TourType>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TourType> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(TourType tourType)
        {
            _dbSet.Update(tourType);

            await _context.SaveChangesAsync();
        }
    }
}