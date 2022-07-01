using Microsoft.EntityFrameworkCore;
using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modsen.App.DataAccess.Repositories
{
    public class EFTourRepository : IRepository<Tour>
    {
        private ApplicationContext _context;
        private DbSet<Tour> _dbSet;

        public EFTourRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Tour>();
        }

        public async Task AddAsync(Tour tour)
        {
            await _dbSet.AddAsync(tour);
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

        public async Task<IEnumerable<Tour>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Tour> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(Tour tour)
        {
            _dbSet.Update(tour);

            await _context.SaveChangesAsync();
        }
    }
}