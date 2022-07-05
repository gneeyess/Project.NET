using System;
using Modsen.App.Core.Models;
using Modsen.App.DataAccess.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class EFBookingRepository : IRepository<Booking>
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Booking> _dbSet;

        public EFBookingRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Booking>();
        }
        public async Task<Booking> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Booking>> GetQueueAsync(int offset, int size)
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
        public async Task UpdateAsync(Booking booking)
        {
            _dbSet.Update(booking);

            await _context.SaveChangesAsync();
        }
        public async Task AddAsync(Booking booking)
        {
            await _dbSet.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
    }
}