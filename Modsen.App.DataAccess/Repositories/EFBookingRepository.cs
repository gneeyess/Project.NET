using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class EFBookingRepository : IRepository<Booking>
    {
        private ApplicationContext _context;
        private DbSet<Booking> _dbSet;

        public EFBookingRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Booking>();
        }

        public async Task AddAsync(Booking booking)
        {
            await _dbSet.AddAsync(booking);
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

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(Booking booking)
        {
            _dbSet.Update(booking);

            await _context.SaveChangesAsync();
        }
    }
}