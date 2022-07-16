using System;
using Modsen.App.DataAccess.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class BookingRepository : IRepository<Booking>
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Booking> _dbSet;

        //1
        public BookingRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Booking>();
        }
        //2
        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        //3
        public async Task<IEnumerable<Booking>> GetQueueAsync(int offset, int size)
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
        public async Task UpdateAsync(Booking booking)
        {
            _dbSet.Update(booking);

            await _context.SaveChangesAsync();
        }
        //6
        public async Task AddAsync(Booking booking)
        {
            await _dbSet.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
    }
}